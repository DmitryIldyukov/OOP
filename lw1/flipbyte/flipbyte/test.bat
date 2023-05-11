@echo off

chcp 65001

set PROGRAM="%~1"

%PROGRAM% 6 > %TEMP%\out.txt || goto err
fc %TEMP%\out.txt test1-out.txt || goto err
del %TEMP%\out.txt
echo Test 1 passed!

%PROGRAM% 255 > %TEMP%\out.txt || goto err
fc %TEMP%\out.txt test2-out.txt || goto err
del %TEMP%\out.txt
echo Test 2 passed!

%PROGRAM% 256 > %TEMP%\out.txt || goto err
fc %TEMP%\out.txt test3-out.txt || goto err
del %TEMP%\out.txt
echo Test 3 passed!

%PROGRAM% Hi He > %TEMP%\out.txt || goto err
fc %TEMP%\out.txt test4-out.txt || goto err
del %TEMP%\out.txt
echo Test 4 passed!

echo All tests passed!
exit /B 0

:err
echo Testing failed
exit /B 0
