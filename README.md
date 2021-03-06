IOSSideBar
==========

Пример реализации сайдбара. Описанный подход удобен в случае если sidebar нужен не на всех экрананх в приложении, а лишь на некоторых. Это подход поддерживает показ SideBar'a по нажатию на какую-то кнопку (вызов метода показа). Т.е. этот подход не поддерживает показ SideBar'а c помощью жестов Pan/DragAndDrop/Swipe

При реализации данного подхода у сайдбара будет нормальный жизненый цикл: Вызваны методы Appear/Disappear.

Основная идея – инкапсулировать код показа/скрытия в одном классе-посреднике, который организует взаимодействие ViewController и SideBarController.

Участники:
 - ContentViewController – UIViewController, отображающий какой-то контент у которого есть кнопка по нажатию на которую необходимо показать SideBar
 - SideBarViewController – UIViewController, который отображает элементы сайдбара. В приложениях чаще всего в этой роли выступает UIViewController у которого внутри есть таблица.
 - SideBarMediator – POCO класс который получает ссылки на экземпляры ContentViewController и SideBarViewController.

При необходимости показать/скрыть сайдбар ContentViewController делегирует эту задачу посреднику SideBarMediator.

![Alt](Preview/photo1.png)
![Alt](Preview/photo2.png)
