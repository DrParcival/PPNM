
Out.txt    :    main.exe
	mono $< 1> $@ 2> log


main.exe : main.cs QRGS.dll
	mcs main.cs -reference:QRGS.dll -target:exe -out:main.exe

QRGS.dll : QRGS.cs matrix.cs vector.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


clean:
	$(RM) *.exe *.dll [Oo]ut*
