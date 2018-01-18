
![N|Solid](https://github.com/nrkdrk/IBS-HR-Teknik/blob/master/images/nrkdrk.jpg)

# IBS-HR-Teknik
IBS-HR-Teknik Servis takip uygulaması

| Menu   | Detay(Detail) |
| ------ | ------ |
| Teknik Kayıt | Servis bölümüne gelen cihazların kayıt sistemi |
| Teknik İşlemler | Servise girişi yapılan cihazların işleme alınması |
| Teknik Liste | Teknik işleme alınan cihazlar(tamamlanan ve tamamlanmayan) |
| Hibe Kayıt | Servise(Firmaya) hibe edilme|
| Hibe Liste | Firmaya hibe edilen cihaz kayıtları|
| Servis Kayıt | Dışarı teknik servis kaydı |
| Servis Listesi | Dışarı teknik servis listesi |

Ana Menü(Main Menu)
![alt text](https://github.com/nrkdrk/IBS-HR-Teknik/blob/master/images/AnaMenu.PNG)

Hibe Kayıt(grant registration)
![alt text](https://github.com/nrkdrk/IBS-HR-Teknik/blob/master/images/HibeKayıt.PNG)

Teknik Kayıt(Technical Registration)
![alt text](https://github.com/nrkdrk/IBS-HR-Teknik/blob/master/images/MenuTeknikKayıt.PNG)

Teknik İslemler(Technical Works)
![alt text](https://github.com/nrkdrk/IBS-HR-Teknik/blob/master/images/Teknikİslemler.PNG)

Projede Veri Tabanı olarak SQL Server 2012 kullanılmıştır.
![alt text](https://github.com/nrkdrk/IBS-HR-Teknik/blob/master/images/sql-server-2012-logo.jpg)

Projedeki bütün veri tabanı tabloları proje içerisinde ana sınıf(class) içerisinde kodla hazırlanmıştır.
Dikkat edilmesi gerek nokta Server bağlantı bilgileri static olarak kodlar içersinde o bilgileri güncellemeniz gerekmektedir.




function test(){
    console.log("Hello world!");
}
(function(){
    var box = function(){
        return box.fn.init();
    };
    box.prototype = box.fn = {
        init : function(){
            console.log('box.init()');
            return this;
        },
        add : function(str){
            alert("add", str);
            return this;
        },
        remove : function(str){
            alert("remove", str);
            return this;
        }
    };
    box.fn.init.prototype = box.fn;
    window.box =box;
})();
var testBox = box();
testBox.add("jQuery").remove("jQuery");
