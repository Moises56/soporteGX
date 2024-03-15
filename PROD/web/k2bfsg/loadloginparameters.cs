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
   public class loadloginparameters : GXProcedure
   {
      public loadloginparameters( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public loadloginparameters( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out short aP0_AmountOfCharacters ,
                           out short aP1_AmountOfFailedLogins ,
                           out bool aP2_BadLoginsExpire ,
                           out bool aP3_ShouldAddSleepOnFailure )
      {
         this.AV8AmountOfCharacters = 0 ;
         this.AV9AmountOfFailedLogins = 0 ;
         this.AV10BadLoginsExpire = false ;
         this.AV11ShouldAddSleepOnFailure = false ;
         initialize();
         executePrivate();
         aP0_AmountOfCharacters=this.AV8AmountOfCharacters;
         aP1_AmountOfFailedLogins=this.AV9AmountOfFailedLogins;
         aP2_BadLoginsExpire=this.AV10BadLoginsExpire;
         aP3_ShouldAddSleepOnFailure=this.AV11ShouldAddSleepOnFailure;
      }

      public bool executeUdp( out short aP0_AmountOfCharacters ,
                              out short aP1_AmountOfFailedLogins ,
                              out bool aP2_BadLoginsExpire )
      {
         execute(out aP0_AmountOfCharacters, out aP1_AmountOfFailedLogins, out aP2_BadLoginsExpire, out aP3_ShouldAddSleepOnFailure);
         return AV11ShouldAddSleepOnFailure ;
      }

      public void executeSubmit( out short aP0_AmountOfCharacters ,
                                 out short aP1_AmountOfFailedLogins ,
                                 out bool aP2_BadLoginsExpire ,
                                 out bool aP3_ShouldAddSleepOnFailure )
      {
         loadloginparameters objloadloginparameters;
         objloadloginparameters = new loadloginparameters();
         objloadloginparameters.AV8AmountOfCharacters = 0 ;
         objloadloginparameters.AV9AmountOfFailedLogins = 0 ;
         objloadloginparameters.AV10BadLoginsExpire = false ;
         objloadloginparameters.AV11ShouldAddSleepOnFailure = false ;
         objloadloginparameters.context.SetSubmitInitialConfig(context);
         objloadloginparameters.initialize();
         Submit( executePrivateCatch,objloadloginparameters);
         aP0_AmountOfCharacters=this.AV8AmountOfCharacters;
         aP1_AmountOfFailedLogins=this.AV9AmountOfFailedLogins;
         aP2_BadLoginsExpire=this.AV10BadLoginsExpire;
         aP3_ShouldAddSleepOnFailure=this.AV11ShouldAddSleepOnFailure;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadloginparameters)stateInfo).executePrivate();
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
         AV8AmountOfCharacters = 5;
         AV9AmountOfFailedLogins = 1;
         AV10BadLoginsExpire = true;
         AV11ShouldAddSleepOnFailure = true;
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

      private short AV8AmountOfCharacters ;
      private short AV9AmountOfFailedLogins ;
      private bool AV10BadLoginsExpire ;
      private bool AV11ShouldAddSleepOnFailure ;
      private short aP0_AmountOfCharacters ;
      private short aP1_AmountOfFailedLogins ;
      private bool aP2_BadLoginsExpire ;
      private bool aP3_ShouldAddSleepOnFailure ;
   }

}
