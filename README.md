Для запуска и работы проекта нужно подключиться к своей базе данных postgresql и сделать миграцию в нее

Для этого в файле appsettings.json найдите строку подключения:
"ConnectionStrings": {
  "DefaultConnection": "User ID=username;Password=password;Host=hostname либо adress;Port=port;Database=database;"
},

Вместо username, password, hostaname/adress, port и database вписываем данные вашей бд
Затем делаете миграцию из проекта в вашу бд
