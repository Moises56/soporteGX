using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", false);
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      void executePrivate( )
      {
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void Reorganizesoporte( )
      {
         string cmdBuffer = "";
         /* Indices for table soporte */
         /* Using cursor P00012 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            constid = P00012_Aconstid[0];
            nconstid = P00012_nconstid[0];
            xtype = P00012_Axtype[0];
            nxtype = P00012_nxtype[0];
            parent_obj = P00012_Aparent_obj[0];
            nparent_obj = P00012_nparent_obj[0];
            cmdBuffer = "ALTER TABLE " + "[" + "soporte" + "] DROP CONSTRAINT " + constid;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cmdBuffer=" ALTER TABLE [soporte] ALTER COLUMN [soporteID] int NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE [soporte] ADD PRIMARY KEY([soporteID]) "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      private void TablesCount( )
      {
         if ( ! IsResumeMode( ) )
         {
            /* Using cursor P00023 */
            pr_default.execute(1);
            soporteCount = P00023_AsoporteCount[0];
            pr_default.close(1);
            PrintRecordCount ( "soporte" ,  soporteCount );
         }
      }

      private bool PreviousCheck( )
      {
         if ( ! IsResumeMode( ) )
         {
            if ( GXUtil.DbmsVersion( context, "DEFAULT") < 10 )
            {
               SetCheckError ( GXResourceManager.GetMessage("GXM_bad_DBMS_version", new   object[]  {"2012"}) ) ;
               return false ;
            }
         }
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         if ( GXUtil.IsSQLSERVER2005( context, "DEFAULT") )
         {
            /* Using cursor P00034 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               sSchemaVar = P00034_AsSchemaVar[0];
               nsSchemaVar = P00034_nsSchemaVar[0];
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         else
         {
            /* Using cursor P00045 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               sSchemaVar = P00045_AsSchemaVar[0];
               nsSchemaVar = P00045_nsSchemaVar[0];
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
         return true ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "Reorganizesoporte" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"soporte", ""}) );
      }

      private void SetPrecedenceris( )
      {
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void UtilsCleanup( )
      {
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         constid = "";
         nconstid = false;
         xtype = "";
         nxtype = false;
         scmdbuf = "";
         P00012_Aconstid = new string[] {""} ;
         P00012_nconstid = new bool[] {false} ;
         P00012_Axtype = new string[] {""} ;
         P00012_nxtype = new bool[] {false} ;
         P00012_Aparent_obj = new int[1] ;
         P00012_nparent_obj = new bool[] {false} ;
         P00023_AsoporteCount = new int[1] ;
         sSchemaVar = "";
         nsSchemaVar = false;
         P00034_AsSchemaVar = new string[] {""} ;
         P00034_nsSchemaVar = new bool[] {false} ;
         P00045_AsSchemaVar = new string[] {""} ;
         P00045_nsSchemaVar = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_Aconstid, P00012_Axtype, P00012_Aparent_obj
               }
               , new Object[] {
               P00023_AsoporteCount
               }
               , new Object[] {
               P00034_AsSchemaVar
               }
               , new Object[] {
               P00045_AsSchemaVar
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected int parent_obj ;
      protected int soporteCount ;
      protected string scmdbuf ;
      protected string sSchemaVar ;
      protected bool nconstid ;
      protected bool nxtype ;
      protected bool nparent_obj ;
      protected bool nsSchemaVar ;
      protected string constid ;
      protected string xtype ;
      protected IGxDataStore dsDefault ;
      protected IDataStoreProvider pr_default ;
      protected string[] P00012_Aconstid ;
      protected bool[] P00012_nconstid ;
      protected string[] P00012_Axtype ;
      protected bool[] P00012_nxtype ;
      protected int[] P00012_Aparent_obj ;
      protected bool[] P00012_nparent_obj ;
      protected GxCommand RGZ ;
      protected int[] P00023_AsoporteCount ;
      protected string[] P00034_AsSchemaVar ;
      protected bool[] P00034_nsSchemaVar ;
      protected string[] P00045_AsSchemaVar ;
      protected bool[] P00045_nsSchemaVar ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          Object[] prmP00034;
          prmP00034 = new Object[] {
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT name, xtype, parent_obj FROM [sysobjects] WHERE (xtype = 'PK') AND (parent_obj = OBJECT_ID('soporte')) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT COUNT(*) FROM [soporte] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT SCHEMA_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT USER_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
       }
    }

 }

}
