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
namespace GeneXus.Programs {
   public class k2bloadrowsperpage : GXProcedure
   {
      public k2bloadrowsperpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bloadrowsperpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_GridName ,
                           out short aP2_RowsPerPage ,
                           out bool aP3_HasConfiguration )
      {
         this.AV10ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV11RowsPerPage = 0 ;
         this.AV9HasConfiguration = false ;
         initialize();
         executePrivate();
         aP2_RowsPerPage=this.AV11RowsPerPage;
         aP3_HasConfiguration=this.AV9HasConfiguration;
      }

      public bool executeUdp( string aP0_ProgramName ,
                              string aP1_GridName ,
                              out short aP2_RowsPerPage )
      {
         execute(aP0_ProgramName, aP1_GridName, out aP2_RowsPerPage, out aP3_HasConfiguration);
         return AV9HasConfiguration ;
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_GridName ,
                                 out short aP2_RowsPerPage ,
                                 out bool aP3_HasConfiguration )
      {
         k2bloadrowsperpage objk2bloadrowsperpage;
         objk2bloadrowsperpage = new k2bloadrowsperpage();
         objk2bloadrowsperpage.AV10ProgramName = aP0_ProgramName;
         objk2bloadrowsperpage.AV8GridName = aP1_GridName;
         objk2bloadrowsperpage.AV11RowsPerPage = 0 ;
         objk2bloadrowsperpage.AV9HasConfiguration = false ;
         objk2bloadrowsperpage.context.SetSubmitInitialConfig(context);
         objk2bloadrowsperpage.initialize();
         Submit( executePrivateCatch,objk2bloadrowsperpage);
         aP2_RowsPerPage=this.AV11RowsPerPage;
         aP3_HasConfiguration=this.AV9HasConfiguration;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bloadrowsperpage)stateInfo).executePrivate();
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
         AV13SessionString = AV12Session.Get(StringUtil.Trim( AV10ProgramName)+StringUtil.Trim( AV8GridName)+"RowsPerPage");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SessionString)) )
         {
            AV11RowsPerPage = (short)(Math.Round(NumberUtil.Val( StringUtil.Trim( AV13SessionString), "."), 18, MidpointRounding.ToEven));
            AV9HasConfiguration = true;
         }
         else
         {
            new k2bretrieverowsperpage(context ).execute(  AV10ProgramName,  AV8GridName, out  AV11RowsPerPage, out  AV9HasConfiguration) ;
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
         AV13SessionString = "";
         AV12Session = context.GetSession();
         /* GeneXus formulas. */
      }

      private short AV11RowsPerPage ;
      private string AV10ProgramName ;
      private string AV8GridName ;
      private string AV13SessionString ;
      private bool AV9HasConfiguration ;
      private IGxSession AV12Session ;
      private short aP2_RowsPerPage ;
      private bool aP3_HasConfiguration ;
   }

}
