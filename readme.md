# GitContextMenuListRemoteBranchesCOM

open git remote branches from windows context menu (C#, Windows 8, 8.1, 10, Net 4.5, Visual Studio 2013)

##Контекстное меню со списком удалённых репозиториев для git-репозитория

Выводит в контекстном меню список http(s)-адресов и переходит на них при нажатии на каталог с репозиторием

##Результат:

![](help/pasted_image003.png)

##Установка (install)


1. Клонировать (Clone):

![](help/pasted_image.png)


2. Запустить solution (Start solution):


![](help/pasted_image001.png)

3. Запустить пересборку (Start rebuild)


![](help/pasted_image002.png)


4. Теперь можно запустить установку msi-пакета (Now you can run install an msi package)

![](help/pasted_image004.png)

Теперь программа готова к работе. Открывайте каталог с репозиторием удобным способом и пользуйтесь.


5. При деинсталляция пакета остаются заблокированными пути установки сервера. Для разблокировки нужно перезапустить explorer.exe (Program path is blocked on uninstall. You should restart explorer.exe on Task Manager and remove application path):


![](help/pasted_image005.png)

После этого каталог установки можно удалить вручную.


##Ручное удаление (manual install/uninstall application)

"C:\Program Files (x86)\GitContextMenuListRemoteBranchesCOM\srm.exe" uninstall "C:\Program Files (x86)\GitContextMenuListRemoteBranchesCOM\GitContextMenuListRemoteBranchesCOM.dll"


##Ручная установка:
	
"C:\Program Files (x86)\GitContextMenuListRemoteBranchesCOM\srm.exe" uninstall "C:\Program Files (x86)\GitContextMenuListRemoteBranchesCOM\GitContextMenuListRemoteBranchesCOM.dll"



