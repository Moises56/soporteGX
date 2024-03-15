/*
				   File: type_SdtK2BActivityList_K2BActivityListItem
			Description: K2BActivityList
				 Author: Nemo 🐠 for C# version 18.0.5.175581
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="K2BActivityListItem")]
	[XmlType(TypeName="K2BActivityListItem" , Namespace="test" )]
	[Serializable]
	public class SdtK2BActivityList_K2BActivityListItem : GxUserType
	{
		public SdtK2BActivityList_K2BActivityListItem( )
		{
			/* Constructor for serialization */
		}

		public SdtK2BActivityList_K2BActivityListItem(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			if (gxTv_SdtK2BActivityList_K2BActivityListItem_Activity != null)
			{
				AddObjectProperty("Activity", gxTv_SdtK2BActivityList_K2BActivityListItem_Activity, false);
			}

			AddObjectProperty("IsAuthorized", gxTpr_Isauthorized, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Activity")]
		[XmlElement(ElementName="Activity")]
		public GeneXus.Programs.SdtK2BActivity gxTpr_Activity
		{
			get {
				if ( gxTv_SdtK2BActivityList_K2BActivityListItem_Activity == null )
				{
					gxTv_SdtK2BActivityList_K2BActivityListItem_Activity = new GeneXus.Programs.SdtK2BActivity(context);
				}
				return gxTv_SdtK2BActivityList_K2BActivityListItem_Activity; 
			}
			set {
				gxTv_SdtK2BActivityList_K2BActivityListItem_Activity = value;
				SetDirty("Activity");
			}
		}
		public void gxTv_SdtK2BActivityList_K2BActivityListItem_Activity_SetNull()
		{
			gxTv_SdtK2BActivityList_K2BActivityListItem_Activity_N = true;
			gxTv_SdtK2BActivityList_K2BActivityListItem_Activity = null;
		}

		public bool gxTv_SdtK2BActivityList_K2BActivityListItem_Activity_IsNull()
		{
			return gxTv_SdtK2BActivityList_K2BActivityListItem_Activity == null;
		}
		public bool ShouldSerializegxTpr_Activity_Json()
		{
			return gxTv_SdtK2BActivityList_K2BActivityListItem_Activity != null;

		}


		[SoapElement(ElementName="IsAuthorized")]
		[XmlElement(ElementName="IsAuthorized")]
		public bool gxTpr_Isauthorized
		{
			get {
				return gxTv_SdtK2BActivityList_K2BActivityListItem_Isauthorized; 
			}
			set {
				gxTv_SdtK2BActivityList_K2BActivityListItem_Isauthorized = value;
				SetDirty("Isauthorized");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BActivityList_K2BActivityListItem_Activity_N = true;


			return  ;
		}



		#endregion

		#region Declaration

		protected GeneXus.Programs.SdtK2BActivity gxTv_SdtK2BActivityList_K2BActivityListItem_Activity = null;
		protected bool gxTv_SdtK2BActivityList_K2BActivityListItem_Activity_N;
		 

		protected bool gxTv_SdtK2BActivityList_K2BActivityListItem_Isauthorized;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BActivityListItem", Namespace="test")]
	public class SdtK2BActivityList_K2BActivityListItem_RESTInterface : GxGenericCollectionItem<SdtK2BActivityList_K2BActivityListItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BActivityList_K2BActivityListItem_RESTInterface( ) : base()
		{	
		}

		public SdtK2BActivityList_K2BActivityListItem_RESTInterface( SdtK2BActivityList_K2BActivityListItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Activity", Order=0, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtK2BActivity_RESTInterface gxTpr_Activity
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Activity_Json())
					return new GeneXus.Programs.SdtK2BActivity_RESTInterface(sdt.gxTpr_Activity);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Activity = value.sdt;
			}
		}

		[DataMember(Name="IsAuthorized", Order=1)]
		public bool gxTpr_Isauthorized
		{
			get { 
				return sdt.gxTpr_Isauthorized;

			}
			set { 
				sdt.gxTpr_Isauthorized = value;
			}
		}


		#endregion

		public SdtK2BActivityList_K2BActivityListItem sdt
		{
			get { 
				return (SdtK2BActivityList_K2BActivityListItem)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtK2BActivityList_K2BActivityListItem() ;
			}
		}
	}
	#endregion
}