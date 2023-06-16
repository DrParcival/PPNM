Out.txt    :    main.exe
	mono $< 1> $@ 2> log


main.exe : main.cs EVD.dll
	mcs main.cs -reference:EVD.dll -target:exe -out:main.exe

EVD.dll : EVD.cs matrix.cs vector.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


clean:
	$(RM) *.exe *.dll [Oo]ut*