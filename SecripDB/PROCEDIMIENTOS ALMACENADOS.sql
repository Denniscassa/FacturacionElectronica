/*
* =============================PROCEDIMIENTOS ALMACENADOS  ============================
*	fecha:		27/10/2021
*	autor:		Yonder quispe
				Dennis casalipa
*	proyecto:	app_topnevel
*	descripcion:registro de procedimientos almacenados
* =======================================================================================
*/


use db_topnevel;

--===========================================PRODUCTOS===================================

--LISTAR PRODUCTOS
create proc SPLISTAR_PRODUCTOS
AS 
SELECT * FROM T_PRODUCTO
GO
--AGREGAR PRODUCTOS
--MODIFICAR PRODUCTOS
--ELIMINAR PRODUCTOS

EXEC SPLISTAR_PRODUCTOS


--===========================================INVENTARIOS===================================

