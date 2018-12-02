def checkTwice(str):
    flag = False
    alphabet ={
        "a":0,"b":0,"c":0,"d":0,"e":0,"f":0,"g":0,"h":0,"i":0,"j":0,"k":0,"l":0,"m":0,"n":0,"o":0,"p":0,"q":0,"r":0,"s":0,"t":0,"u":0,"v":0,"x":0,"y":0,"z":0, "w":0
    }
    for ch in str:
        alphabet[ch]+= 1
    for key in alphabet:
        if alphabet[key] == 2:
            flag = True
    return flag
def checkTriple(str):
    flag = False
    alphabet ={
        "a":0,"b":0,"c":0,"d":0,"e":0,"f":0,"g":0,"h":0,"i":0,"j":0,"k":0,"l":0,"m":0,"n":0,"o":0,"p":0,"q":0,"r":0,"s":0,"t":0,"u":0,"v":0,"x":0,"y":0,"z":0, "w":0
    }
    for ch in str:
        alphabet[ch]+= 1
    for key in alphabet:
        if alphabet[key] == 3:
            flag=True
    return flag
def oneLetter(s1,s2):
    differences = 0
    for k in range(len(s2)):
        if s1[k] != s2[k]:
            differences +=1
    if differences == 1:
        return True
    return False
f = open("q2.txt", "r")
list = f.readlines()
list = map(lambda s: s.strip(), list)
f.close()
twice = 0
triple = 0
result = "wrong"
for string in list:
    if (checkTwice(string)):
        twice+= 1
    if (checkTriple(string)):
        triple+= 1
print (twice * triple), "\n"
for i in range(len(list)):
    for j in range(i+1,len(list)):
        if oneLetter(list[i],list[j]):
            result =""
            for k,l in zip(list[i],list[j]):
                if k == l:
                    result += k
            pass
print result