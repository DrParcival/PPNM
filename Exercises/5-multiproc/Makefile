TIME = time --portability --append --output $@

N = 2e8
Out.txt : main.exe
	>$@
	$(TIME) mono main.exe -terms:$N -threads:1 >> $@
	$(TIME) mono main.exe -terms:$N -threads:2 >> $@
	$(TIME) mono main.exe -terms:$N -threads:3 >> $@
	$(TIME) mono main.exe -terms:$N -threads:4 >> $@
	$(TIME) mono main.exe -terms:$N -threads:5 >> $@
	$(TIME) mono main.exe -terms:$N -threads:6 >> $@
	$(TIME) mono main.exe -terms:$N -threads:7 >> $@
	$(TIME) mono main.exe -terms:$N -threads:8 >> $@

main.exe : main.cs
	mcs $<

N1=2.01e8
N2=2.02e8
N3=2.03e8
N4=2.04e8
N5=2.05e8
N6=2.06e8
N7=2.07e8
N8=2.08e8

test: out1 out2 out3 out4 out5 out6 out7 out8 # trying to 8 tests
out1: main.exe
	mono main.exe -terms:$(N1) -threads:1 > $@
out2: main.exe
	mono main.exe -terms:$(N2) -threads:1 > $@
out3: main.exe
	mono main.exe -terms:$(N3) -threads:1 > $@
out4: main.exe
	mono main.exe -terms:$(N4) -threads:1 > $@
out5: main.exe
	mono main.exe -terms:$(N5) -threads:1 > $@
out6: main.exe
	mono main.exe -terms:$(N6) -threads:1 > $@
out7: main.exe
	mono main.exe -terms:$(N7) -threads:1 > $@
out8: main.exe
	mono main.exe -terms:$(N8) -threads:1 > $@



test2: main.exe
	mono main.exe -terms:$(N1) -threads:1 > out1 &
	mono main.exe -terms:$(N2) -threads:1 > out2 &
	mono main.exe -terms:$(N3) -threads:1 > out3 &
	mono main.exe -terms:$(N4) -threads:1 > out4 &
	mono main.exe -terms:$(N5) -threads:1 > out5 &
	mono main.exe -terms:$(N6) -threads:1 > out6 &
	mono main.exe -terms:$(N7) -threads:1 > out7 &
	mono main.exe -terms:$(N8) -threads:1 > out8 &


clean:
	$(RM) [Oo]ut*
