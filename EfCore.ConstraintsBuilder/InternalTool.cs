﻿using System.Text;
using System.Text.RegularExpressions;

namespace EfCore.ConstraintsBuilder;

public static class InternalTool
{
  public const string EmailRegex = "^[^@]+@[^@]+$";
  public const string UrlRegex = @"^(http://|https://|ftp://)";
  public const string PhoneNumberRegex = @"^(\+?1)?[2-9]\d{2}[2-9](?!11)\d{6}$";
  public const string CreditCardRegex = @"^(\d{4}[- ]){3}\d{4}|\d{16}$";
  
  
  public static string CreateUniqueConstraintName(string tableName, string columnName, string suffix, bool addRandomSuffix = true) {
    var sb = new StringBuilder();
    sb.Append("CK_");
    sb.Append(tableName);
    sb.Append('_');
    sb.Append(columnName);
    sb.Append('_');
    sb.Append(suffix);
    if (!addRandomSuffix) return sb.ToString();
    sb.Append('_');
    sb.Append(Guid.NewGuid().ToString().Replace("-", ""));
    return sb.ToString();
  }

  public static bool IsValidRegex(string regex) {
    try {
      _ = new Regex(regex);
      return true;
    }
    catch (ArgumentException) {
      return false;
    }
  }
}