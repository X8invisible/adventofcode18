f = open("q1.txt", "r")
list = f.readlines()
f.close()
results = map(int, list)
outp = 0
for number in results:
	outp += number
print outp