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
namespace GeneXus.Programs.k2bfsg {
   public class loadrecoverpasswordrequirementsparameters : GXProcedure
   {
      public loadrecoverpasswordrequirementsparameters( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public loadrecoverpasswordrequirementsparameters( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out bool aP0_RequireEmail ,
                           out bool aP1_RequireFirstName ,
                           out bool aP2_RequireBirthday )
      {
         this.AV9RequireEmail = false ;
         this.AV10RequireFirstName = false ;
         this.AV8RequireBirthday = false ;
         initialize();
         executePrivate();
         aP0_RequireEmail=this.AV9RequireEmail;
         aP1_RequireFirstName=this.AV10RequireFirstName;
         aP2_RequireBirthday=this.AV8RequireBirthday;
      }

      public bool executeUdp( out bool aP0_RequireEmail ,
                              out bool aP1_RequireFirstName )
      {
         execute(out aP0_RequireEmail, out aP1_RequireFirstName, out aP2_RequireBirthday);
         return AV8RequireBirthday ;
      }

      public void executeSubmit( out bool aP0_RequireEmail ,
                                 out bool aP1_RequireFirstName ,
                                 out bool aP2_RequireBirthday )
      {
         loadrecoverpasswordrequirementsparameters objloadrecoverpasswordrequirementsparameters;
         objloadrecoverpasswordrequirementsparameters = new loadrecoverpasswordrequirementsparameters();
         objloadrecoverpasswordrequirementsparameters.AV9RequireEmail = false ;
         objloadrecoverpasswordrequirementsparameters.AV10RequireFirstName = false ;
         objloadrecoverpasswordrequirementsparameters.AV8RequireBirthday = false ;
         objloadrecoverpasswordrequirementsparameters.context.SetSubmitInitialConfig(context);
         objloadrecoverpasswordrequirementsparameters.initialize();
         Submit( executePrivateCatch,objloadrecoverpasswordrequirementsparameters);
         aP0_RequireEmail=this.AV9RequireEmail;
         aP1_RequireFirstName=this.AV10RequireFirstName;
         aP2_RequireBirthday=this.AV8RequireBirthday;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadrecoverpasswordrequirementsparameters)stateInfo).executePrivate();
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
         AV9RequireEmail = true;
         AV10RequireFirstName = false;
         AV8RequireBirthday = true;
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
         /* GeneXus formulas. */
      }

      private bool AV9RequireEmail ;
      private bool AV10RequireFirstName ;
      private bool AV8RequireBirthday ;
      private bool aP0_RequireEmail ;
      private bool aP1_RequireFirstName ;
      private bool aP2_RequireBirthday ;
   }

}
