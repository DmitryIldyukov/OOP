@echo off

chcp 65001
set PROGRAM="%~1"

::�������� �� ������� �������
%PROGRAM% test1.txt > %TEMP%\out.txt || goto err
fc %TEMP%\out.txt test1-out.txt || goto err

::�������� �� �������, � ������� ��� �������� �������
%PROGRAM% test2.txt > %TEMP%\out.txt
fc %TEMP%\out.txt test2-out.txt || goto err

::�������� �� ������������ ���������� ���������� ����������
%PROGRAM% test3.txt 0 > %TEMP%\out.txt
fc %TEMP%\out.txt test3-out.txt || goto err

::�������� �� �������������� ����
%PROGRAM% not-exist.txt > %TEMP%\out.txt
fc %TEMP%\out.txt test4-out.txt || goto err

::�������� �� ��������� �������
%PROGRAM% test5.txt > %TEMP%\out.txt
fc %TEMP%\out.txt test5-out.txt || goto err

::�������� �� ������� �������
%PROGRAM% test6.txt > %TEMP%\out.txt
fc %TEMP%\out.txt test6-out.txt || goto err

echo All tests passed!
exit /B 0

:err
echo Testing failed
exit /B 1