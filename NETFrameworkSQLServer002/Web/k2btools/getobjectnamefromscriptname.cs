using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.k2btools {
   public class getobjectnamefromscriptname : GXProcedure
   {
      public getobjectnamefromscriptname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public getobjectnamefromscriptname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ScriptName ,
                           out string aP1_ObjectName )
      {
         this.AV8ScriptName = aP0_ScriptName;
         this.AV9ObjectName = "" ;
         initialize();
         executePrivate();
         aP1_ObjectName=this.AV9ObjectName;
      }

      public string executeUdp( string aP0_ScriptName )
      {
         execute(aP0_ScriptName, out aP1_ObjectName);
         return AV9ObjectName ;
      }

      public void executeSubmit( string aP0_ScriptName ,
                                 out string aP1_ObjectName )
      {
         getobjectnamefromscriptname objgetobjectnamefromscriptname;
         objgetobjectnamefromscriptname = new getobjectnamefromscriptname();
         objgetobjectnamefromscriptname.AV8ScriptName = aP0_ScriptName;
         objgetobjectnamefromscriptname.AV9ObjectName = "" ;
         objgetobjectnamefromscriptname.context.SetSubmitInitialConfig(context);
         objgetobjectnamefromscriptname.initialize();
         Submit( executePrivateCatch,objgetobjectnamefromscriptname);
         aP1_ObjectName=this.AV9ObjectName;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getobjectnamefromscriptname)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ObjectName = AV8ScriptName;
         if ( ( new GeneXus.Programs.k2btools.getgenexusgenerator(context).executeUdp( ) == 2 ) && StringUtil.EndsWith( StringUtil.Trim( StringUtil.Lower( AV8ScriptName)), context.GetMessage( ".aspx", "")) )
         {
            AV9ObjectName = StringUtil.Substring( AV8ScriptName, 1, StringUtil.Len( AV8ScriptName)-5);
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV9ObjectName = "";
         /* GeneXus formulas. */
      }

      private string AV8ScriptName ;
      private string AV9ObjectName ;
      private string aP1_ObjectName ;
   }

}
