circle.svg : circle.gpi circle.data
	gnuplot $<


Out.txt    :    main.exe
	mono $< 1> $@ 2> log

circle.data: circle.exe
	mono $< > $@

circle.exe: circle.cs matrix.dll
	mcs -target:exe -reference:matrix.dll $<


main.exe : main.cs matrix.dll
	mcs main.cs -reference:matrix.dll -target:exe -out:main.exe

matrix.dll : matrix.cs vector.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


clean:
	$(RM) *.exe *.dll *.svg [Oo]ut*
