@echo off

chcp 65001
set PROGRAM="%~1"

:: Тестируем на регистр букв
%PROGRAM% test1.txt "Hello he" > %TEMP%\out.txt || goto err
fc %TEMP%\out.txt test1-out.txt || goto err
echo test 1 passed!

:: Тестируем пустой текст
%PROGRAM% test2.txt "" > %TEMP%\out.txt
fc %TEMP%\out.txt test2-out.txt || goto err

:: Тестируем на поиск несуществующего текста
%PROGRAM% test3.txt Anton > %TEMP%\out.txt
fc %TEMP%\out.txt test3-out.txt || goto err

:: Самый обычный тест
%PROGRAM% test4.txt family > %TEMP%\out.txt || goto err
fc %TEMP%\out.txt test4-out.txt || goto err

echo All tests passed!
exit /B 0

:err
echo Testing failed
exit /B 1