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
   public class k2bsavegridstate : GXProcedure
   {
      public k2bsavegridstate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bsavegridstate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_SessionStateParameter ,
                           SdtK2BGridState aP2_GridState )
      {
         this.AV10ProgramName = aP0_ProgramName;
         this.AV9SessionStateParameter = aP1_SessionStateParameter;
         this.AV8GridState = aP2_GridState;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_SessionStateParameter ,
                                 SdtK2BGridState aP2_GridState )
      {
         k2bsavegridstate objk2bsavegridstate;
         objk2bsavegridstate = new k2bsavegridstate();
         objk2bsavegridstate.AV10ProgramName = aP0_ProgramName;
         objk2bsavegridstate.AV9SessionStateParameter = aP1_SessionStateParameter;
         objk2bsavegridstate.AV8GridState = aP2_GridState;
         objk2bsavegridstate.context.SetSubmitInitialConfig(context);
         objk2bsavegridstate.initialize();
         Submit( executePrivateCatch,objk2bsavegridstate);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsavegridstate)stateInfo).executePrivate();
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
         AV11Session.Set(AV10ProgramName+AV9SessionStateParameter+"GridState", AV8GridState.ToXml(false, true, "", ""));
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
         AV11Session = context.GetSession();
         /* GeneXus formulas. */
      }

      private string AV10ProgramName ;
      private string AV9SessionStateParameter ;
      private IGxSession AV11Session ;
      private SdtK2BGridState AV8GridState ;
   }

}
