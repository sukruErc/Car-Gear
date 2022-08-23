18 Mayis

*Oyunu kafamdan gecirdim ve hemen iki arabanin karsilikli gelebilecegi bir zemin hazirladim. Ilk basta araba icin bir 
hareket mekanizmasi yapip bunu hem player icin hem de hazirlayacagim AI icin kullanacagim.

*Oyuncunun satin alabilecegi 3 tane etmen olmasi gerektigine karar kildim. biri arabanin agirligi digeri hizi bir digeri ise itis(vites) gucu

*Muhtemelen agirlik ve hiz degiskenlerini satin almak cok kolay olacaktir direk arabanin icersindeki tanimlanmis degerlerin uzerine eklenerek devam edilecektir.

*Vites icin 2 adet buton dusunuyorum bir tanesi arabaya gaz verip bir digeri belirtilen araliga gelindiginde vites atmasini yani arabaya itis gucu saglamasi hedeflendi

*Su an AI icin bir sey dusunmedim ama oyuna player icin alacagim upgradelerin en azindan bir kaci AI ya uygulanmassa oyun cok kolay olur.

*AI icin 3 saniyede bir atabilecegi bir itis kuvveti ayarlayacagim ama bunun kesinlikle belli bir degerin uzerinde olmasi disinda bir randomize eklemek istiyorum
boylece bot surekli ayni itme gucunu almayip karsisinda gercekten bir player varmis hissiyati verebilirim.

- Araba ekledim ve bu arabanin gidebilmesi icin 4 ceker bir araba sistemi tasarladim, motor ve agirlik gucuyle calisan bu sistemi abstract class ile yazip
Ai uzerinede ekledim. Denemek icin ai uzerine 3 saniyede bir gelen bir itis gucu verdim. playerin ustune tiklanildiginda ise ona itis gucu veren bir mekanizma hazirladim

- UI hazirladim, Bu UI uzerinde engine body ve gear adi altinda 3 adet satin alinabilir icerik koydum, Win condisyonunda 1000 
lose condisyonunda da 1000=? ancak kendini tekrar eden lose condisyonlarinda atanilan intiger deger kadar bu sayi bolumme ugrayacaktir.

-Su an mouseinput ile gecis yaptigim oyun ekranina Time scale kullanarak arabalari durdurdum. Time scale in daha saglikli olabilecegini dusundum, Bunu 
Awake metoduna yazarak olasi buglardan sakindim.(arabanin saniyelik hareket etmesi gibi). Bunu ilerde degistirebilirim.

-Level Manager ekledim, icine normalde 2 tane condisyon koyacaktim ama su an sadece aracin statlarini kontrol etmek icin kaybetme collideri koydum. Bu oyunun time scale
ini 0 layip scenin restartlamasini sagliyor.

-AI icin oranlarinin artip azalan bir sistem yapilmali.


/*------------------------------------------------------------------------*/

19 Mayis

*Arabanin satin alim sirasinda yasadigi problemi cozdum, Artik hem satin aldiginda hem de satin almadiginda elindeki valueyle yani player prefle oynayabiliyor.

*Bir slider ekledim bu slider mouse tusuna basildiginda doluyor biraktiginda azaliyor, space tusuna basildiginda belli bir miktar geri gidiyor. Saridaysa 0 a yesildeyse biraz ortaya kirmizida bastiysa 
0 a yakin bir degerden gaza basmaya basliyor.

*Slider ve araba iliskisi cozuldu, Artik problemsiz bir sekilde arabaya vites atabiliyoruz. Araba kirmizi cizgiye 2,5 saniye boyunca durursa arac bozuluyor oyuncu kontrolu kaybediyor,
muhtemelen ai da itecegi icin bir sure sonra oyunu kazaniyor.

/*------------------------------------------------------------------------*/
 
20 Mayis 

*Dun playerla ilgili her seyi tamamladim, sadece AI in nasil bir davranis yapacagini cozmem lazim.

*Butonlar androide gore uyarlandim, 2 kere basma gibi olusan bugu cozdum(oyun baslarken otomatik vites atmaya calisiyor, oyunu yavaslatiyordu)

*Yeni bir Ai sistemi oturtuldu, AI in ne zaman guclunip guclenmeyecegi oyuncunun kazanmasiyla cozuldu.

*kontroller degisti, Tap and hold sistemi yapidi(space kullaniliyordu dokunmatik ekran icin uyarlandi).

/*------------------------------------------------------------------------*/

21 Mayis

Ai level dizayni eklendi , her level aldiginda aracin rengi degisiyor 

Oyunun testleri android uzerinden yapildi eksikler giderildi.


/*-----------------------------------------------------------------------*/


OYUN MEKANIKLERI

Genel olarak bahsedecek olursam 3 farkli etmen var;

Oynanis: Ekrana basili tutularak oynanan oyunda yesile geldiginde biraktigimizda arabamiza bir itme gucu veriyoruz. Yesile geldiginde 1 itme gucu veriliyorsa kirmiziya gelindiginde bunun
yarisi kadar itme gucu veriliyor, Eger kirmizi saha icerisinde belirli bir sure kalinirsa araba istop edip kontrol edilemez hale geliyor.

--Arac motor gucu alirsa AI'i daha rahat yakaliyor ancak itme konusunda hic bir etkisi yok ama usteki gas pedalinin hizi artiyor boylece daha hizli itme gucu yakalayabiliyor.
--Arac agirlik alirsa AI'in onu yakalamasini kolaylastiriyor ancak AI'in itme gucunu azaltiyor.
--Arac itme gucu aldiginda gas pedalinin vites atma suresini hizlandiriyor.

--Player her satin aldigi guclendirmeyle arabasini gelistiriyor, aldigi urunun bir sonraki seviye icin fiyati artiyor.

--Ai icin yaptiklarim ise playerdan her zaman agirlik olarak guclu kalmak boylece oyunu daha oynayabilir kilabilmek, level 1 disindaki bot disinda genel olarak oyuncunun bir sey
yapmadan kazanmasi neredeyse imkansiz.  AI her bolum kazanildiginda statlari belli bir duzeyde artip yeni bir arac goruntusune buruyor.

--IdleManager icerisinde RestartGame()'in comment kismi silinirse oyun 0 dan basliyor.

--Son olarak oyunu 1920x1080 Landscape'te calistim. Canvasimi da bu boyutta kullanip, pivotlarimida bu sekilde ayarladim.
