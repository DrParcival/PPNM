all: Out.txt rmax.svg dr.svg wavefunction.svg

rmax.svg : rmax.gpi Out.txt
	gnuplot $<

dr.svg : dr.gpi Out.txt
	gnuplot $<

wavefunction.svg : wavefunction.gpi Out.txt
	gnuplot $<

Out.txt    :    main.exe
	mono $< > $@


main.exe : main.cs EVD.dll
	mcs main.cs -reference:EVD.dll -target:exe -out:main.exe

EVD.dll : EVD.cs matrix.cs vector.cs
	mcs -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


clean:
	$(RM) *.exe *.dll *.svg [Oo]ut*