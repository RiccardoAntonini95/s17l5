# Istruzioni per il database
## Prima di tutto creare un nuovo database da SQL Server Management Studio 19
### Successivamente bisognerà eseguire i file presenti nel progetto per creare le tabelle e popolarle
All'interno del progetto è presente una cartella di nome SQL, con al suo interno 3 file .sql per creare il database è necessario aprire i 3 file dall'esplora risorse ed eseguirne la relativa query nel database creato nell'ordine seguente:
```
CreateDatabase
PopulateDb
PopulateVerbale
```

### Per concludere va cambiata la connection string per la connessione al Db, che è contenuta in Models/ConnDb.cs
