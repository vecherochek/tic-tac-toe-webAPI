# Задача

Спроектируйте и реализуйте REST API для игры в крестики нолики

## Описание

Для разработки сайта и мобильного приложения для игры в крестики нолики 3x3 для двух игроков требуется реализовать web api. Игра проходит по обычным правилам.

## Формат решения

### Обязательно:

- проект должен быть выложен на GitHub и открываться с помощьюм VS2022
- в readme.md репозитория или на выделенной онлайн странице должно быть описание API

### Опционально:
- проект собирается в докер и разворачиватся в рабочее состояние docker-compose
- API должно быть опубликовано в интернет

## Решение:

### [Документация](https://github.com/vecherochek/tic-tac-toe-webAPI/wiki)
#### Примечание:
Есть возможность развернуть docker-compose. Только в файле ([TicTacToe.API/DAL/Repositories/Contexts/GameDbContext.cs](https://github.com/vecherochek/tic-tac-toe-webAPI/blob/master/TicTacToe.API/DAL/Repositories/Contexts/GameDbContext.cs)) поменяйте в connection string Ip сервера на IPv4-адрес вашей машины. Понимаю, что захаркоженная строка это плохо....
