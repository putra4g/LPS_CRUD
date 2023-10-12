# LPS_CRUD
Point A. Test .NET Core MVC - LPS - MSBU

# Cara Menjalankan Aplikasi
1. Buka Folder Repository project LPS_CRUD kedalam visual studio
   
2. Buka Folder "SQL" > copy script DB_LPS_CRUD.sql ke sql editor > run > pastikan schema database LPS sudah tercreate
   
3. Ubah connection string pada file appsettings.json menjadi seperti ini :
```
   "ConnectionStrings": {
     "MysqlconnectionString": "Server=localhost,Port=3306;Database=[NamaDataBase];Uid=[NamaUser];Pwd=[PasswordDataBase];"
   }
```

4. Jalankan aplikasi dengan menekan tombol RUN pada visual studio

5. Untuk Melihat Vidio demo aplikasi dapa dilihat di folder "Video"
