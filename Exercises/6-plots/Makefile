DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)


Gamma.svg : gamma.gpi gamma.data factorials.data
	gnuplot $<

Erf.svg : erf.gpi erf.data
	gnuplot $<

gamma.data : main.exe
	mono $< > $@

erf.data : main.exe
	mono $< > $@

main.exe : main.cs sfuns.dll
	mcs -target:exe -out:$@ $(CODE) $(DLLS)

sfuns.dll : erf.cs gamma.cs
	mcs -target:library -out:$@ $(CODE)

factorials.data : Makefile
	>$@
	echo 0 1 >>$@
	echo 1 1 >>$@
	echo 2 2 >>$@
	echo 3 6 >>$@
	echo 4 24 >>$@
	echo 5 120 >>$@
	echo 6 $$(echo '6*120' | bc) >>$@

main: main.exe sfuns.dll
	mkbundle -o $@ --simple $^

clean:
	$(RM) *.exe *.dll *.svg *.data main
