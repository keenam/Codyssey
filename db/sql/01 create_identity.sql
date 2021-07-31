create table Identity 
(
  id int not null primary key,
  context text not null unique,
  nextid int not null
)
