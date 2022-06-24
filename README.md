# async-integration-between-services
simple implimentation of masstransit over rabbitMQ using masstransit .netCore helper package

Masstransit built-in headerlarından olan conversationId bilgisi send veya publish mesaj iletim tekniklerinden herhangi biri kullanılırken context üzerinden custom işaretlenmektedir.
Dolayısıyla producer-consumer iletişimindeki log yönetiminde kullanılabilecek correlation bu taşınan conversationId header bilgisi üzerinden yapılabilir.

Consumer uygulama ayağa kalkmadan kuyruk rabbitmq instance üzerinde oluşmayacağı şeklinde bir tabu var fakat mesaj iletim yöntemi send olduğunda ki bu solutionda bu örnek var,
sendendpoint bus üzerinden alınırken parametre olarak pass edilen uri bilgisinde queue:{queue-name} ifadesi ile producer uygulama consumer öncesi ayağa kaldırılırsa 
kuyruk rabbitMQ instance üzerinde oluşturulabilir.

Consumer uygulamada unhandled bir exception ile karşılaşılması durumunda, ilgili exceptionın loglanması için yine masstransit'in getirdiği bir çözüm var.
Fault consumer. Bu consumer syntax regular consumer implimanstasyondan pek farklı değil sadece IConsumer<Fault<T>> şeklinde inheritence alması lazım. 
Dolayısıyla ilk olarak mesaj regular consumera düşer unhandled exception oluşması durumunda bu fault consumera exception detayıyla mesaj yansır ve olağan akış devam eder.
