
GO
/****** Object:  StoredProcedure [dbo].[fwk_Param_exist]    Script Date: 2/8/2020 1:22:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	             --------------------------------------------------------------------------------------------
	              -- Author     :		 moviedo
	              -- Date       :	   2019-11-04T17:37:33
	              -- Description: 	 [Description]
	              --------------------------------------------------------------------------------------------
	      CREATE PROCEDURE [dbo].[fwk_Param_exist]
      	
	      (	@ParamId int = null ,
			@ParentId int  = NULL,
		 	@Culture char(5) = null
)
      	
	      AS
 
  SELECT
	CASE when  EXISTS(   SELECT * FROM fwk_Param WHERE  
				  (@ParamId is null or ParamId =@ParamId)
				  and				  (@ParentId is null or ParentId =@ParentId)
				  and				  (@Culture is null or Culture =Culture)
				  )THEN 1 
       ELSE 0 
   END
				  
	

GO
/****** Object:  StoredProcedure [dbo].[fwk_Param_g]    Script Date: 2/8/2020 1:22:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	             --------------------------------------------------------------------------------------------
	              -- Author     :		 moviedo
	              -- Date       :	   2019-11-04T17:37:33
	              -- Description: 	 [Description]
	              --------------------------------------------------------------------------------------------
	      create PROCEDURE [dbo].[fwk_Param_g]
      	
	      (	
	  	   @ParamId int  ,
			
		 	@Culture char(5) = null
)
      	
	      AS
 
  
	SELECT * FROM fwk_Param WHERE  
				  (ParamId =@ParamId) and (@Culture is null or Culture =Culture)	
  
        
GO
/****** Object:  StoredProcedure [dbo].[fwk_Param_i]    Script Date: 2/8/2020 1:22:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	             --------------------------------------------------------------------------------------------
	              -- Author     :		 moviedo
	              -- Date       :	   2019-11-04T17:37:33
	              -- Description: 	 [Description]
	              --------------------------------------------------------------------------------------------
	      CREATE PROCEDURE [dbo].[fwk_Param_i]
      	
	      (	@ParamId int ,
	@ParentId int  = NULL,
	@Name varchar(50) ,
	@Description varchar(50)  = NULL,
	@Enabled bit ,
	@Culture char(5) ,
	@Id int OUTPUT
)
      	
	      AS
      					
      					
	      
          
         
          INSERT INTO fwk_Param
          (
          ParamId
,ParentId
,Name
,Description
,Enabled
,Culture
,Id


          )
          VALUES
          (
          @ParamId,
@ParentId,
@Name,
@Description,
@Enabled,
@Culture,
@Id

          )
            
          
				
	        Set @Id = @@Identity
					
        

        
      					

GO
/****** Object:  StoredProcedure [dbo].[fwk_Param_s]    Script Date: 2/8/2020 1:22:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	             --------------------------------------------------------------------------------------------
	              -- Author     :		 moviedo
	              -- Date       :	   2019-11-04T17:37:33
	              -- Description: 	 [Description]
	              --------------------------------------------------------------------------------------------
	      CREATE PROCEDURE [dbo].[fwk_Param_s]
      	
	      (	
	  	   @ParentId int  = null,
			
		 	@Culture char(5) = null
)
      	
	      AS
 
  
	SELECT * FROM fwk_Param WHERE  
				  (@ParentId is null or ParentId =@ParentId) and (@Culture is null or Culture =Culture)	
  
        
GO
