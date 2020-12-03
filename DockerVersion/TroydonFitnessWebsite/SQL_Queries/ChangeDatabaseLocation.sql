-- Relocate database

ALTER DATABASE ProductContext_59a25d91_3b23_442e_9df3_9a1daed97a84 SET OFFLINE;
ALTER DATABASE ProductContext_59a25d91_3b23_442e_9df3_9a1daed97a84 MODIFY FILE ( NAME = 'ProductContext-59a25d91-3b23-442e-9df3-9a1daed97a84', FILENAME = 'M:\Users\troyi\Databases\TroydonFitnessDatabases\ProductContext_59a25d91_3b23_442e_9df3_9a1daed97a84.mdf');
ALTER DATABASE ProductContext_59a25d91_3b23_442e_9df3_9a1daed97a84 MODIFY FILE ( NAME = 'ProductContext-59a25d91-3b23-442e-9df3-9a1daed97a84_log', FILENAME = 'M:\Users\troyi\Databases\TroydonFitnessDatabases\ProductContext_59a25d91_3b23_442e_9df3_9a1daed97a84_log.ldf');
ALTER DATABASE ProductContext_59a25d91_3b23_442e_9df3_9a1daed97a84 SET ONLINE;
-- Verify database added
SELECT name, physical_name AS CurrentLocation, state_desc  
FROM sys.master_files  
WHERE database_id = DB_ID(N'<ProductContext_59a25d91_3b23_442e_9df3_9a1daed97a84>');  