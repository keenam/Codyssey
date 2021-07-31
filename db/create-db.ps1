# Creates a new sqlite3 database with the scripts
# instead of relying code-based EF
# this gives is a full-control.

$db_file_path = '..\test.db'

function Get-Max {
  [CmdletBinding()]
  param (
      [Parameter()]
      [int]
      $x,
      [Parameter()]
      [int]
      $y
  )

  if ($x -ge $y) {
    return $x
  } else {
    return $y
  }
}

function Ensure-EmptyFile {
  [CmdletBinding()]
  param (
      [Parameter()]
      [string]
      $file_path
  )

  while ($true) {
    if (Test-Path $file_path) {
      Write-Host "Do you want to delete $file_path`? [y/N] " -NoNewline
      $response = Read-Host
      if ($response.Length -eq 0) {
        $response = 'n'
      }

      if ('y' -eq $response) {
        Remove-Item $file_path -ErrorAction Stop
      } elseif ('n' -eq $response) {
        throw "$file already exists."
      }
    } else {
      return
    }
  }
}

try {
  Ensure-EmptyFile $db_file_path
} catch {
  return
}

$line_length = 120
$ok = ' OK'
$fail = ' Error'
$pad_char = '.'

Get-ChildItem .\sql -File | ForEach-Object {
  $message = "Applying $($_.Name) "
  $pad_length = $line_length - $message.Length - (Get-Max $ok.Length $fail.Length)
  if ($pad_length -gt 0) {
    $message = $message + ($pad_char * $pad_length)
  }
  Write-Host $message -NoNewline
  $sql = Get-Content $_.FullName -Raw
  $result = sqlite3 $db_file_path $sql
  
  if ($?) {
    Write-Host $ok
  } else {
    Write-Host $fail
    throw $result
  }
}
