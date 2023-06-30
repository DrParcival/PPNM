spline.svg : spline.gpi spline.data
	gnuplot $<

integral.svg : integral.gpi spline.data
	gnuplot $<

step.svg : step.gpi step.data
	gnuplot $<

Out.txt    :    main.exe
	mono $< 1> $@ 2> log


main.exe : main.cs matrix.dll
	mcs main.cs -reference:matrix.dll -target:exe -out:main.exe

matrix.dll : matrix.cs vector.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


clean:
	$(RM) *.exe *.dll *.svg [Oo]ut*
