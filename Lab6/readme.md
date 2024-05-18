Часть I
Ввести в строку /My/Start/0
Ввести данные
Получить результат
Вернуться назад
Удалить значение в ID, и не пройти дальше совершив RedirectToAction сюда же

Часть II
Фильтр авторизации:
Models/MyAuthorize.cs
Там получаются значения. Если их нет или они неправильные, ошибки переходят в фильтр исключений

Фильтр исключений:
Для проверки работы ArgumentOutOfRange и FormatException:
Перейти сюда - /Home/Index?id=0&method=Start 
ArgumentOutOfRange: /Home/Index?id=0
FormatException: /Home/Index?id=basasa&method=Start 

Фильтр дейcтвия:
Ввести отрицательный ID
Произойдет перенаправление на NegativeNumbers.cshtml