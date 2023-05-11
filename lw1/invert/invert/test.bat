@echo off

chcp 65001
set PROGRAM="%~1"

::Проверка на обычную матрицу
%PROGRAM% test1.txt > %TEMP%\out.txt || goto err
fc %TEMP%\out.txt test1-out.txt || goto err

::Проверка на матрицу, у которой нет обратной матрицы
%PROGRAM% test2.txt > %TEMP%\out.txt
fc %TEMP%\out.txt test2-out.txt || goto err

::Проверка на неправильное количество переданных аргументов
%PROGRAM% test3.txt 0 > %TEMP%\out.txt
fc %TEMP%\out.txt test3-out.txt || goto err

::Проверка на несуществующий файл
%PROGRAM% not-exist.txt > %TEMP%\out.txt
fc %TEMP%\out.txt test4-out.txt || goto err

::Проверка на единичную матрицу
%PROGRAM% test5.txt > %TEMP%\out.txt
fc %TEMP%\out.txt test5-out.txt || goto err

::Проверка на нулевую матрицу
%PROGRAM% test6.txt > %TEMP%\out.txt
fc %TEMP%\out.txt test6-out.txt || goto err

echo All tests passed!
exit /B 0

:err
echo Testing failed
exit /B 1