Caching Nedir?

Çok sık kullanılan dataları kaydedilmesi ve ihtiyaç halinde okunmasına caching denir.

Caching Çeşitleri nelerdir?

In-memory Caching
Distributed Caching


In-memory Caching nedir?

Verileri ram üzerinde tuttuğumuz kısma denir. 
Eğer 2 ayrı sunucuda aynı uygulamayı kurup ayağa kaldırır isek farklı data gözükmeleri yaşanabilir. Bu problemi her istek atan kişiyi ilk istek attığı sunucuya yönlendirirsek diğer attığı isteklerde kısmı bir çözüm uygulamış oluruz.

Distributed Caching nedir?

Verilerin ayağa kaldırmış olduğumuz sunucuda değil ayrı bir shared cache servisinde tutulmasına denir.

On-Demand Caching nedir?

Datayı sadece talep olduğunda cacheleme işlemi yapılır.

Prepopulation Caching nedir?

Uygulamayı ayağa kaldırdığımızda bir datayı cacheleme yapmak istiyorsak kullanılır.


Cache ömrü (Absolute time ve Sliding time) nedir?

Bir datayı cache yaparken kaç gün kalabileceğini belirleyebiliyoruz.

Absolute time=Ömrü 5 dakika verdiğimizi varsayarsak 5 dakika sonra veri kaybolur.
Sliding time=Ömrü 5 dakika verdiğimizi varsayarak verdiğimiz süre içinde erişim olursa ömrü 5 daika daha artırmış oluruz.

Cache Priority

Bellek doluluğunun kontrolünde vazgeçmemiz gereken verilerde öncelik verip işlem yapılması gereken veriyi önceliklendirmiş oluruz.

RegisterPostEvictionCallback Method

Memory'den bir data düştüğünde düşen datanın hangi sebepten düştüğünü bulmamızı sağlar.


Redis(Remote Dictionary Server) nedir?

Opensource olarak geliştirilen ve dataları tutan nosql bir veritabanıdır. Veri tiplerine sahiptir.


Redis Veri Tipleri Nelerdir?

1-Redis String
2-Redis List
3-Redis Set
4-Redis Sorted Set
5-Redis hash

Redis-Cli ile işlemler

SET name umut - umut adında bir string oluşturur

GET name - umut sonucunu bize döner yani okuma işini yapar.

GETRANGE name 0 2 - substr gibi işlem yapar.

INCR ziyaretçi - ziyaretçi olarak tanımlanmış bir datamız sayısal ise artırma işlemini yapar.

INCRBY ziyaretçi 10 - ziyaretçi sayısını belirttiğimiz kadar artırır.

DECR ziyaretçi - ziyaretçi sayısını 1 azaltır.

DECRBY ziyaretçi 10 - ziyaretçi sayısını belirttiğimiz kadar azaltır.

APPEND name emre - name keyword'üne emreyi ekler.

LPUSH kitaplar kitap2 - dizi oluşturur(list) içine eleman ekler.

RPUSH kitaplar kitap2 - dizinin sonuna ekler.

LRANGE kitaplar 0 2 - kitaplar listesinde 0dan 2ye kadar olanları getirir

LRANGE kitaplar 0 -1 tümünü gösterir.

LPOP kitaplar - baştan bir değer siler

RPOP kitaplar - sondan bir değer siler.

LINDEX kitaplar 1 - birinci index'e sahip değer gelir

SADD color blue - Uniq tanımlayıcıya sahip liste elemanı oluşturur

SADD color red

SMEMBERS color - dataları listeler

SREM color red - red keyine sahip değeri siler.

ZADD kitaplar 1 kitap1 - bir skor değeri ile sorted list oluşturulur. score göre sıralama yapılır.

ZREM kitaplar kitap22 - değer silmeye yarar.

HMSET sozluk pen kalem - key value şeklinde data eklenir. c#taki dictionary gibi

HGET sozluk book - veriyi getirir

HDEL sozluk book - siler.

HGETALL sozluk - dataları listeler













