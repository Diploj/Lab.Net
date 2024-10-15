# Чат
Данное приложение реализует онлай форум, где люди могут общатся на различные темы
## Требование к проекту
### 1) Регистрация пользователя
+ Для использования чата пользователям необходимо указать
  - Никнейм
  - Пароль
  - Номер телефона или адрес электронной почты
+ С одного адреса электронной почты или номера телефона можно создать лишь один аккаунт
### 2) Логин и логаут пользователя
+ Для входа в чат пользователю необходиммо ввести никнейм и пароль
+ В случае утери пароля, пользователь может запросить востанновление пароля (при условии что к аккаунту привязан адресс электронной почты)
### 3) (INDEX) Просмотр списка записей
+ Пользователь может просматривать последние 10000 сообщений
+ По самого сообщения пользователь видит
  - Дату отправки
  - Имя автора сообщения
### 4) (CREATE) Создание записи
+ Пользователь может создать сообщение, написав его в поле ввода и нажав кнопку отправить
+ После отправки сообщение становится видно другим пользователям
### 5) (UPDATE) Редактирование записи
+ При нажатии на специальную кнопку и выборе необходимого сообщения, пользователь может изменить его содержание
+ В начале редактирования текст сообщения автоматически подставляется в поле ввода
### 6) (DELETE) Просмотр деталей записи
+ Пользователь при нажатии на кнопку "Удалить сообщение" пользователь может удалить выюранное сообщение
+ Пользователь может удалить только свое сообщение
+ При удалении будет выведенно предупреждение, что данное действие не обратимо.
+ После удаленния сообщение пропадает из чата для всех пользователей
### 7) Права администратора
+ Удалять любое сообщение
+ Блокировать пользователя на время или навсегда
+ Разблокировать пользователя
## База данных
![модель-1](https://github.com/user-attachments/assets/7d289b08-e8ef-48bb-9fdb-27d90f0dab30)
