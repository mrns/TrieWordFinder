# Goal

Task goal details can be found in "Developer Exercise - WordFinder.pdf", located in the root of this repo.

# QuTask.WordFinder

This is the main class library project which contains the actual code used to solve the excercise. I decided to use a Trie
structure for multiple reasons.

1. The input matrix has a fixed size and does not change.
2. The data to store was normal strings and the search target were actual words.
3. Given that:

   1. A match could be located at any point in the matrix, from left to right and top to bottom.
   2. The input word stream to search could be arbitrarily large.

   I needed structure that would both minimize the in memory footprint as well as reduce the search complexity as much as possible. The Trie fits perfectly for this by storing repetitive strings in a very efficient char node -> chidlren nodes structure which in turn reduces the algorithmic complexity to O(m), where m is the length of the string.

   I studied this structure a while ago but I had been hearing a lot about it lately since several cryptocurrencies such as Ethereum and Rootstock are moving their core data structures into a Trie implementation.

Also it is worth noting that before creating the Trie index I map the input IEnumerable<string> to an actual multidimensional char[,] structure to simplify the code involved in creating the index. This does not affect the performance at all and improves mantenability, reduces bugs, etc.

# QuTask.Tools

Contains some static methods related to Word and Matrix manipulation and test data generation. I Chose to use a separate library because I used some of their methods from both QuTask.Tests and QuTask.Runner. Changing these methods will affect the test and runner results.

# QuTask.Tests

Contains at least one test for each specific requirement described in the PDF file.

```
cd ./QuTask.Tests/
dotnet test

Starting test execution, please wait...

Total tests: 10. Passed: 10. Failed: 0. Skipped: 0.
Test Run Successful.
Test execution time: 2.0025 Seconds

```

# QuTask.Runner

Console application that performs a search on a squared matrix (defaults to 64x64) which is prepopulated
with mostly random characters and a few specific horizontal and vertical words using i === j, with i < 15
as starting points.

```
cd ./QuTask.Runner/
dotnet run

----------------------------------------------------
SEEDED WORDS:
----------------------------------------------------

"one#",
"two#",
"two#",
"three#",
"three#",
"three#",
"four#",
"five#",
"six#",
"seven#",
"eight#",
"nine#",
"ten#",
"eleven#",
"twelve#"

----------------------------------------------------
MATRIX:
----------------------------------------------------

one#ewcdbpvvpcadljgwrucjybqphqipyvmsfseugplidpbcagadnuqivcbcgmuk
ntwo#gxsfkpbitgjynobqeceedwdrbotubbwshmthhxdepabuqcrwssbdrpliubd
ewtwo#prbutjgyynduhaxvwbhytbqakmfuhijsilakqcyjuesbinmaeyyeysooba
#owthree#uynftbweoiorvyephjesowkiprsgimcwwbqbptecboyglingxujfyqw
x#ohthree#rtuidanfbqywewhdlhndvwfdsnkebtjtwbtorxuuuawaxbjhhxvjgy
jt#rhthree#eacdrknmshuaffqddwcwanxqyabiffmvpssbgeomivnqnthkxllka
kgqerhfour#tyjmmpwyipneygdespkstbuemcyuawddobwojuxholckvbquhyxtt
nrreerofive#joxiotwqcehyjikkdmbxjiaiekeunpmmryllrlseacrijssvoxnn
xlc#eeuisix#quhkvxsqtvxgqrykqhfpcxofvkxdhpnwyfroliyqfvtbnujvptlh
wmjr#erviseven#lykxihojfenqabbmndgaluyijtnpplpsnmxvfudyiddnqknjy
cvaby##exeeight#udmdehsahrhrkryfdqnpornqhvdfnfjkjxvgagutdashnxoi
oiphedy##vinine#hwhlurfwvtloxgcigtqeocffysreklpqnqyqpcnwdskkqkei
slbjvgmfqegiten#euaghlsdgtbvqunoojkyjgugesynplvcgbfvjwagsxccfpov
mxmppmyxanhneeleven#oreqiefldsbnedbqyfmtbhupumtokhegaxgusuhlgnth
rnjidvuql#tenltwelve#tnfvfwdxbmnnmwgdllomnuekyweylbqnxtwydlwxqsk
hasjqorxek###ewwiselyvaosagaynquukwjfnmjtdlcptwqhooemgkkaepqhrxp
tneolkqtgtqukvexcprjylhnyljbwubceuibphewxtxrpoaceroqyophfqpybpwk
sopoowitkulfneljkgvfgjcpfavyreuhvnyaxlnhitfedktprfotsrdimajnbjbg
ydiypwlysovldnvtgfgmpaoejpnxbyfxryfybtautobduqeonohvdopxoepyimws
jwtdqmslfkrby#erkyjmrjucjhkwealgqitwwbwavuprwnyetwojdkbycqsjcuhf
xlkqpltjbjqvsc#vhgchlcdfgtughmwankskdhnicehstfgykwcvsytvhejupmco
lphijuryrsegtjlbnvvjkbhoqwcyxssocsgdwwopecdytmcxrigsqrdkisrmrsby
apebdhdpggfhwhtduegolyxjovudfcwlaeyehbtjeqmjmunaynrmllnartlhmajd
ithsiovtkvktmnwthterkkyopxmmomwegibrnurkrxcpasndwryrursxtrckbiew
ygndlefmctamhjnwjipwmeiopcxurgiiseptfjqrlmpbqfpkefasrgjtwynjgjtu
krscssqaqxkangwjmmqmgppmuvvgvhkcrtpylnrknabtujfpbdvtsgnubghvwkdi
miisqxxytfygnuqkpfeslqjkgtxffuncvrhmalycfwamhhhfovgqfkwvywmvarsx
rwkunekdgcmnqvdxmrpiovvktkndxdcmebtkwlqklckdwjfcsoihbkjuayacpged
yaiocsbbafwllrnkfkkjttltrxjwkntfwgewapyamggvnwjilpwevuienowdjeqm
kqofnpjoljwmnpgtobltqoicwyilsvphptkvhetughslwvqwicohrwuuhlhngxvp
towsfjlkgqnjvwebilcpgipryonuvgnhkdrixwrxpdbbikykhfeuufikyetpvpna
cfxrfvclseydgnjnpdnqbrmeugitdccypbydmhekcscqgfdlufarcwxjsswxnihp
banfofbhxdohpuxpcwxwcjwrcojskfwsklofqwvoersxiptxugvpjknrcudaviws
fuvdfrxeajrkpxjltlxdjgiaxwdvtvsvtasmtqrciqoardcdkqfjjtixlvfiobjd
qvpofwrdtvtrrihttyldqilartbwkimggljvnmxnycpnyqgcokoopgmhkpwkutrk
imkfylghbxdnrwabmxiytwqyxblwpmrejeelfadcegnqdxpmovwwlrqkvlgwairn
gyemrnultfumiavakxisotsqnspttfcuoykdtctaalcfwdbuoglbaxylgmxxxbro
dyxjosfiehsdrntjqtemsbuqaywhducxsnbxfrguadvrfutrsogdvfucdgipvxej
etkeludynjloeclfeenonybnrytyjpybymmkkogwkhomsfxbudkqkoufswlmaeox
jkpqoatpxpefjntmbsdgeiqjqhrndswfsqdiogltiustkpvecylhbhsbsfahigle
sxlrklwthixjowyakmldhodlxcoigekcioaledtpcqarjilvgyvvthvduathvnnd
wuaavmvhsubqolboqschhohbrvqdjlsocwunikytcocygfnjxfqdlguhmyiyvsxg
bmnrpmffshermhumhhedupcvbmbjcaxiqvxsqvskykkdbdueeurnntkljrqdlvds
jvbqjbvlosekeytxqvegijuwkmixeoycgrsfbeucyfytoagkxsmpqwkaadfwsxgy
tbdmfovmachcjbhkfwalciljhsfxxxibxaymvteivapoohqyuuquwtwlptemjxnc
sgdibuoksqpcsvtycfcdgndddnvboryxlmuidhwagfcgetrtyfkdvjufcyfmxmva
qqpfblutibwalvxivccjhvccrpfebjctjbonelrnjpttmtsgawqvjlsuonnkfqsx
ydqjhkdjjnaqbhpwvyderfjxityqwhhrwvuidjypshlulbtgxqognnfstsbmlmmc
ghtfmgsmankktnmgarsfrbeipbokhldfuiodgotqwbgacuyggtmttgjeckokqien
jfpkxiykwbhpueftciemxjkoxjbvyiaowrpwfnhwubvsxsjxfuhhdqpytbmngdlo
asscniooagrvnrqeydpdarkfcpcdbtqqohseahjvfshwyslckhndmhnihmaxfkng
paggylerttxhkngieastfmegsjwmgkqteahxmfdycvjsjfwtfrtertbdvymonqki
cdckfhuxwtqickwnmchoqlckxecmsnkkkbpfdmnwvuhwcrakcycljvqqbqlbfifi
jfxbuqkyojrveehfdrktlybnjyelblrnoxnvtypkocvadulvjfxnwlvkejqumxxc
qegfqklebaficbknmhcunepdbcrjhtwpetiyogfxtslwgnidydhfvdnmncenscwh
codhrlygceatrswntojdlrsbfukmcqervetqjakndbdrctttfptersukvccwamek
yixnyfdsdvyknaylapglvaaciiuhxnmqvrssuguylaausjvucpvkfsnxiueqkvuo
iiovhgptuhyvyejylyeirclddtjabdopflmkuamvybpxsrxdkffkrlwfvlsmvpsq
rjpnryellhipmmjkugouxdwsngnigaaiiyfjbkllbtxjdgsjbhqpbxrolwylkuel
hahnhaiktcseemphmehyikgjgqwekaagplcdxecbxguyemjxhrxgmedvsxgpceyt
bmoskmjhcfabphfthxwsbtskigkaxlythbwqwqnuipehecgkrmiehgrgsejecijp
gftnjnwpjbklplfgyyhlctlaipxrgjsyfnbxhradprtfufqhxdecaxmltsespejy
ilfbkhxgyevkagfdypscfpxhaoeomgnkitvjapwqfwdvbclmnbtykhtsmwaucjtr
pkcfjuciscvhmbgwdqaklnaaadvcobnvdlfqafdrxlgiklgkqdrliifcjbfgyatq

----------------------------------------------------
RANKING:
----------------------------------------------------

bus
red
sky
web
three#
two#
one#
four#
five#
six#

----------------------------------------------------
STATS:
----------------------------------------------------

Elapsed Milliseconds: 837
Elapsed Ticks: 3434335
```
