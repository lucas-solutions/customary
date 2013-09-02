/**
 * Autogenerated by Thrift
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Transport;
namespace Custom.Utils.Evernote.EDAM.Type
{

  #if !SILVERLIGHT && !NETFX_CORE
  [Serializable]
  #endif
  public partial class ResourceAttributes : TBase
  {
    private string _sourceURL;
    private long _timestamp;
    private double _latitude;
    private double _longitude;
    private double _altitude;
    private string _cameraMake;
    private string _cameraModel;
    private bool _clientWillIndex;
    private string _recoType;
    private string _fileName;
    private bool _attachment;
    private LazyMap _applicationData;

    public string SourceURL
    {
      get
      {
        return _sourceURL;
      }
      set
      {
        __isset.sourceURL = true;
        this._sourceURL = value;
      }
    }

    public long Timestamp
    {
      get
      {
        return _timestamp;
      }
      set
      {
        __isset.timestamp = true;
        this._timestamp = value;
      }
    }

    public double Latitude
    {
      get
      {
        return _latitude;
      }
      set
      {
        __isset.latitude = true;
        this._latitude = value;
      }
    }

    public double Longitude
    {
      get
      {
        return _longitude;
      }
      set
      {
        __isset.longitude = true;
        this._longitude = value;
      }
    }

    public double Altitude
    {
      get
      {
        return _altitude;
      }
      set
      {
        __isset.altitude = true;
        this._altitude = value;
      }
    }

    public string CameraMake
    {
      get
      {
        return _cameraMake;
      }
      set
      {
        __isset.cameraMake = true;
        this._cameraMake = value;
      }
    }

    public string CameraModel
    {
      get
      {
        return _cameraModel;
      }
      set
      {
        __isset.cameraModel = true;
        this._cameraModel = value;
      }
    }

    public bool ClientWillIndex
    {
      get
      {
        return _clientWillIndex;
      }
      set
      {
        __isset.clientWillIndex = true;
        this._clientWillIndex = value;
      }
    }

    public string RecoType
    {
      get
      {
        return _recoType;
      }
      set
      {
        __isset.recoType = true;
        this._recoType = value;
      }
    }

    public string FileName
    {
      get
      {
        return _fileName;
      }
      set
      {
        __isset.fileName = true;
        this._fileName = value;
      }
    }

    public bool Attachment
    {
      get
      {
        return _attachment;
      }
      set
      {
        __isset.attachment = true;
        this._attachment = value;
      }
    }

    public LazyMap ApplicationData
    {
      get
      {
        return _applicationData;
      }
      set
      {
        __isset.applicationData = true;
        this._applicationData = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT && !NETFX_CORE
    [Serializable]
    #endif
    public struct Isset {
      public bool sourceURL;
      public bool timestamp;
      public bool latitude;
      public bool longitude;
      public bool altitude;
      public bool cameraMake;
      public bool cameraModel;
      public bool clientWillIndex;
      public bool recoType;
      public bool fileName;
      public bool attachment;
      public bool applicationData;
    }

    public ResourceAttributes() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              SourceURL = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I64) {
              Timestamp = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Double) {
              Latitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Double) {
              Longitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Double) {
              Altitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.String) {
              CameraMake = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.String) {
              CameraModel = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.Bool) {
              ClientWillIndex = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.String) {
              RecoType = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.String) {
              FileName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.Bool) {
              Attachment = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.Struct) {
              ApplicationData = new LazyMap();
              ApplicationData.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("ResourceAttributes");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (SourceURL != null && __isset.sourceURL) {
        field.Name = "sourceURL";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(SourceURL);
        oprot.WriteFieldEnd();
      }
      if (__isset.timestamp) {
        field.Name = "timestamp";
        field.Type = TType.I64;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(Timestamp);
        oprot.WriteFieldEnd();
      }
      if (__isset.latitude) {
        field.Name = "latitude";
        field.Type = TType.Double;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Latitude);
        oprot.WriteFieldEnd();
      }
      if (__isset.longitude) {
        field.Name = "longitude";
        field.Type = TType.Double;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Longitude);
        oprot.WriteFieldEnd();
      }
      if (__isset.altitude) {
        field.Name = "altitude";
        field.Type = TType.Double;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Altitude);
        oprot.WriteFieldEnd();
      }
      if (CameraMake != null && __isset.cameraMake) {
        field.Name = "cameraMake";
        field.Type = TType.String;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(CameraMake);
        oprot.WriteFieldEnd();
      }
      if (CameraModel != null && __isset.cameraModel) {
        field.Name = "cameraModel";
        field.Type = TType.String;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(CameraModel);
        oprot.WriteFieldEnd();
      }
      if (__isset.clientWillIndex) {
        field.Name = "clientWillIndex";
        field.Type = TType.Bool;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(ClientWillIndex);
        oprot.WriteFieldEnd();
      }
      if (RecoType != null && __isset.recoType) {
        field.Name = "recoType";
        field.Type = TType.String;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(RecoType);
        oprot.WriteFieldEnd();
      }
      if (FileName != null && __isset.fileName) {
        field.Name = "fileName";
        field.Type = TType.String;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(FileName);
        oprot.WriteFieldEnd();
      }
      if (__isset.attachment) {
        field.Name = "attachment";
        field.Type = TType.Bool;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Attachment);
        oprot.WriteFieldEnd();
      }
      if (ApplicationData != null && __isset.applicationData) {
        field.Name = "applicationData";
        field.Type = TType.Struct;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        ApplicationData.Write(oprot);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ResourceAttributes(");
      sb.Append("SourceURL: ");
      sb.Append(SourceURL);
      sb.Append(",Timestamp: ");
      sb.Append(Timestamp);
      sb.Append(",Latitude: ");
      sb.Append(Latitude);
      sb.Append(",Longitude: ");
      sb.Append(Longitude);
      sb.Append(",Altitude: ");
      sb.Append(Altitude);
      sb.Append(",CameraMake: ");
      sb.Append(CameraMake);
      sb.Append(",CameraModel: ");
      sb.Append(CameraModel);
      sb.Append(",ClientWillIndex: ");
      sb.Append(ClientWillIndex);
      sb.Append(",RecoType: ");
      sb.Append(RecoType);
      sb.Append(",FileName: ");
      sb.Append(FileName);
      sb.Append(",Attachment: ");
      sb.Append(Attachment);
      sb.Append(",ApplicationData: ");
      sb.Append(ApplicationData== null ? "<null>" : ApplicationData.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }

}
