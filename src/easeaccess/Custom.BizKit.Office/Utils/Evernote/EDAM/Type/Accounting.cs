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
  public partial class Accounting : TBase
  {
    private long _uploadLimit;
    private long _uploadLimitEnd;
    private long _uploadLimitNextMonth;
    private PremiumOrderStatus _premiumServiceStatus;
    private string _premiumOrderNumber;
    private string _premiumCommerceService;
    private long _premiumServiceStart;
    private string _premiumServiceSKU;
    private long _lastSuccessfulCharge;
    private long _lastFailedCharge;
    private string _lastFailedChargeReason;
    private long _nextPaymentDue;
    private long _premiumLockUntil;
    private long _updated;
    private string _premiumSubscriptionNumber;
    private long _lastRequestedCharge;
    private string _currency;
    private int _unitPrice;
    private int _businessId;
    private string _businessName;
    private BusinessUserRole _businessRole;

    public long UploadLimit
    {
      get
      {
        return _uploadLimit;
      }
      set
      {
        __isset.uploadLimit = true;
        this._uploadLimit = value;
      }
    }

    public long UploadLimitEnd
    {
      get
      {
        return _uploadLimitEnd;
      }
      set
      {
        __isset.uploadLimitEnd = true;
        this._uploadLimitEnd = value;
      }
    }

    public long UploadLimitNextMonth
    {
      get
      {
        return _uploadLimitNextMonth;
      }
      set
      {
        __isset.uploadLimitNextMonth = true;
        this._uploadLimitNextMonth = value;
      }
    }

    public PremiumOrderStatus PremiumServiceStatus
    {
      get
      {
        return _premiumServiceStatus;
      }
      set
      {
        __isset.premiumServiceStatus = true;
        this._premiumServiceStatus = value;
      }
    }

    public string PremiumOrderNumber
    {
      get
      {
        return _premiumOrderNumber;
      }
      set
      {
        __isset.premiumOrderNumber = true;
        this._premiumOrderNumber = value;
      }
    }

    public string PremiumCommerceService
    {
      get
      {
        return _premiumCommerceService;
      }
      set
      {
        __isset.premiumCommerceService = true;
        this._premiumCommerceService = value;
      }
    }

    public long PremiumServiceStart
    {
      get
      {
        return _premiumServiceStart;
      }
      set
      {
        __isset.premiumServiceStart = true;
        this._premiumServiceStart = value;
      }
    }

    public string PremiumServiceSKU
    {
      get
      {
        return _premiumServiceSKU;
      }
      set
      {
        __isset.premiumServiceSKU = true;
        this._premiumServiceSKU = value;
      }
    }

    public long LastSuccessfulCharge
    {
      get
      {
        return _lastSuccessfulCharge;
      }
      set
      {
        __isset.lastSuccessfulCharge = true;
        this._lastSuccessfulCharge = value;
      }
    }

    public long LastFailedCharge
    {
      get
      {
        return _lastFailedCharge;
      }
      set
      {
        __isset.lastFailedCharge = true;
        this._lastFailedCharge = value;
      }
    }

    public string LastFailedChargeReason
    {
      get
      {
        return _lastFailedChargeReason;
      }
      set
      {
        __isset.lastFailedChargeReason = true;
        this._lastFailedChargeReason = value;
      }
    }

    public long NextPaymentDue
    {
      get
      {
        return _nextPaymentDue;
      }
      set
      {
        __isset.nextPaymentDue = true;
        this._nextPaymentDue = value;
      }
    }

    public long PremiumLockUntil
    {
      get
      {
        return _premiumLockUntil;
      }
      set
      {
        __isset.premiumLockUntil = true;
        this._premiumLockUntil = value;
      }
    }

    public long Updated
    {
      get
      {
        return _updated;
      }
      set
      {
        __isset.updated = true;
        this._updated = value;
      }
    }

    public string PremiumSubscriptionNumber
    {
      get
      {
        return _premiumSubscriptionNumber;
      }
      set
      {
        __isset.premiumSubscriptionNumber = true;
        this._premiumSubscriptionNumber = value;
      }
    }

    public long LastRequestedCharge
    {
      get
      {
        return _lastRequestedCharge;
      }
      set
      {
        __isset.lastRequestedCharge = true;
        this._lastRequestedCharge = value;
      }
    }

    public string Currency
    {
      get
      {
        return _currency;
      }
      set
      {
        __isset.currency = true;
        this._currency = value;
      }
    }

    public int UnitPrice
    {
      get
      {
        return _unitPrice;
      }
      set
      {
        __isset.unitPrice = true;
        this._unitPrice = value;
      }
    }

    public int BusinessId
    {
      get
      {
        return _businessId;
      }
      set
      {
        __isset.businessId = true;
        this._businessId = value;
      }
    }

    public string BusinessName
    {
      get
      {
        return _businessName;
      }
      set
      {
        __isset.businessName = true;
        this._businessName = value;
      }
    }

    public BusinessUserRole BusinessRole
    {
      get
      {
        return _businessRole;
      }
      set
      {
        __isset.businessRole = true;
        this._businessRole = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT && !NETFX_CORE
    [Serializable]
    #endif
    public struct Isset {
      public bool uploadLimit;
      public bool uploadLimitEnd;
      public bool uploadLimitNextMonth;
      public bool premiumServiceStatus;
      public bool premiumOrderNumber;
      public bool premiumCommerceService;
      public bool premiumServiceStart;
      public bool premiumServiceSKU;
      public bool lastSuccessfulCharge;
      public bool lastFailedCharge;
      public bool lastFailedChargeReason;
      public bool nextPaymentDue;
      public bool premiumLockUntil;
      public bool updated;
      public bool premiumSubscriptionNumber;
      public bool lastRequestedCharge;
      public bool currency;
      public bool unitPrice;
      public bool businessId;
      public bool businessName;
      public bool businessRole;
    }

    public Accounting() {
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
            if (field.Type == TType.I64) {
              UploadLimit = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I64) {
              UploadLimitEnd = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I64) {
              UploadLimitNextMonth = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.I32) {
              PremiumServiceStatus = (PremiumOrderStatus)iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.String) {
              PremiumOrderNumber = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.String) {
              PremiumCommerceService = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.I64) {
              PremiumServiceStart = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.String) {
              PremiumServiceSKU = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.I64) {
              LastSuccessfulCharge = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.I64) {
              LastFailedCharge = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.String) {
              LastFailedChargeReason = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.I64) {
              NextPaymentDue = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 13:
            if (field.Type == TType.I64) {
              PremiumLockUntil = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 14:
            if (field.Type == TType.I64) {
              Updated = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 16:
            if (field.Type == TType.String) {
              PremiumSubscriptionNumber = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 17:
            if (field.Type == TType.I64) {
              LastRequestedCharge = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 18:
            if (field.Type == TType.String) {
              Currency = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 19:
            if (field.Type == TType.I32) {
              UnitPrice = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              BusinessId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 21:
            if (field.Type == TType.String) {
              BusinessName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 22:
            if (field.Type == TType.I32) {
              BusinessRole = (BusinessUserRole)iprot.ReadI32();
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
      TStruct struc = new TStruct("Accounting");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.uploadLimit) {
        field.Name = "uploadLimit";
        field.Type = TType.I64;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(UploadLimit);
        oprot.WriteFieldEnd();
      }
      if (__isset.uploadLimitEnd) {
        field.Name = "uploadLimitEnd";
        field.Type = TType.I64;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(UploadLimitEnd);
        oprot.WriteFieldEnd();
      }
      if (__isset.uploadLimitNextMonth) {
        field.Name = "uploadLimitNextMonth";
        field.Type = TType.I64;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(UploadLimitNextMonth);
        oprot.WriteFieldEnd();
      }
      if (__isset.premiumServiceStatus) {
        field.Name = "premiumServiceStatus";
        field.Type = TType.I32;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)PremiumServiceStatus);
        oprot.WriteFieldEnd();
      }
      if (PremiumOrderNumber != null && __isset.premiumOrderNumber) {
        field.Name = "premiumOrderNumber";
        field.Type = TType.String;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(PremiumOrderNumber);
        oprot.WriteFieldEnd();
      }
      if (PremiumCommerceService != null && __isset.premiumCommerceService) {
        field.Name = "premiumCommerceService";
        field.Type = TType.String;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(PremiumCommerceService);
        oprot.WriteFieldEnd();
      }
      if (__isset.premiumServiceStart) {
        field.Name = "premiumServiceStart";
        field.Type = TType.I64;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(PremiumServiceStart);
        oprot.WriteFieldEnd();
      }
      if (PremiumServiceSKU != null && __isset.premiumServiceSKU) {
        field.Name = "premiumServiceSKU";
        field.Type = TType.String;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(PremiumServiceSKU);
        oprot.WriteFieldEnd();
      }
      if (__isset.lastSuccessfulCharge) {
        field.Name = "lastSuccessfulCharge";
        field.Type = TType.I64;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(LastSuccessfulCharge);
        oprot.WriteFieldEnd();
      }
      if (__isset.lastFailedCharge) {
        field.Name = "lastFailedCharge";
        field.Type = TType.I64;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(LastFailedCharge);
        oprot.WriteFieldEnd();
      }
      if (LastFailedChargeReason != null && __isset.lastFailedChargeReason) {
        field.Name = "lastFailedChargeReason";
        field.Type = TType.String;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(LastFailedChargeReason);
        oprot.WriteFieldEnd();
      }
      if (__isset.nextPaymentDue) {
        field.Name = "nextPaymentDue";
        field.Type = TType.I64;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(NextPaymentDue);
        oprot.WriteFieldEnd();
      }
      if (__isset.premiumLockUntil) {
        field.Name = "premiumLockUntil";
        field.Type = TType.I64;
        field.ID = 13;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(PremiumLockUntil);
        oprot.WriteFieldEnd();
      }
      if (__isset.updated) {
        field.Name = "updated";
        field.Type = TType.I64;
        field.ID = 14;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(Updated);
        oprot.WriteFieldEnd();
      }
      if (PremiumSubscriptionNumber != null && __isset.premiumSubscriptionNumber) {
        field.Name = "premiumSubscriptionNumber";
        field.Type = TType.String;
        field.ID = 16;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(PremiumSubscriptionNumber);
        oprot.WriteFieldEnd();
      }
      if (__isset.lastRequestedCharge) {
        field.Name = "lastRequestedCharge";
        field.Type = TType.I64;
        field.ID = 17;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(LastRequestedCharge);
        oprot.WriteFieldEnd();
      }
      if (Currency != null && __isset.currency) {
        field.Name = "currency";
        field.Type = TType.String;
        field.ID = 18;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Currency);
        oprot.WriteFieldEnd();
      }
      if (__isset.unitPrice) {
        field.Name = "unitPrice";
        field.Type = TType.I32;
        field.ID = 19;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(UnitPrice);
        oprot.WriteFieldEnd();
      }
      if (__isset.businessId) {
        field.Name = "businessId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BusinessId);
        oprot.WriteFieldEnd();
      }
      if (BusinessName != null && __isset.businessName) {
        field.Name = "businessName";
        field.Type = TType.String;
        field.ID = 21;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(BusinessName);
        oprot.WriteFieldEnd();
      }
      if (__isset.businessRole) {
        field.Name = "businessRole";
        field.Type = TType.I32;
        field.ID = 22;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)BusinessRole);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Accounting(");
      sb.Append("UploadLimit: ");
      sb.Append(UploadLimit);
      sb.Append(",UploadLimitEnd: ");
      sb.Append(UploadLimitEnd);
      sb.Append(",UploadLimitNextMonth: ");
      sb.Append(UploadLimitNextMonth);
      sb.Append(",PremiumServiceStatus: ");
      sb.Append(PremiumServiceStatus);
      sb.Append(",PremiumOrderNumber: ");
      sb.Append(PremiumOrderNumber);
      sb.Append(",PremiumCommerceService: ");
      sb.Append(PremiumCommerceService);
      sb.Append(",PremiumServiceStart: ");
      sb.Append(PremiumServiceStart);
      sb.Append(",PremiumServiceSKU: ");
      sb.Append(PremiumServiceSKU);
      sb.Append(",LastSuccessfulCharge: ");
      sb.Append(LastSuccessfulCharge);
      sb.Append(",LastFailedCharge: ");
      sb.Append(LastFailedCharge);
      sb.Append(",LastFailedChargeReason: ");
      sb.Append(LastFailedChargeReason);
      sb.Append(",NextPaymentDue: ");
      sb.Append(NextPaymentDue);
      sb.Append(",PremiumLockUntil: ");
      sb.Append(PremiumLockUntil);
      sb.Append(",Updated: ");
      sb.Append(Updated);
      sb.Append(",PremiumSubscriptionNumber: ");
      sb.Append(PremiumSubscriptionNumber);
      sb.Append(",LastRequestedCharge: ");
      sb.Append(LastRequestedCharge);
      sb.Append(",Currency: ");
      sb.Append(Currency);
      sb.Append(",UnitPrice: ");
      sb.Append(UnitPrice);
      sb.Append(",BusinessId: ");
      sb.Append(BusinessId);
      sb.Append(",BusinessName: ");
      sb.Append(BusinessName);
      sb.Append(",BusinessRole: ");
      sb.Append(BusinessRole);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
