class Constants {
  static SharedPref sharedPref = SharedPref();
  static Theme theme = Theme();
  static Status status = Status();
}

class Theme {
  String dark = "dark";
  String light = "light";
  String system = "system";
}

class SharedPref {
  String userIdTag = "user_id";
  String accessTokenTag = "access_token";
  String nameTag = "name";
  String usernameTag = "username";
  String givenNameTag = "given_name";
  String familyNameTag = "family_name";
  String emailTag = "email";
  String roleTag = "role";

  String themeModeTag = "theme_mode";
}

class Status {
  String getStatusName(int status) {
    switch (status) {
      case 0:
        return "Feldolgozás";
      case 1:
        return "Összecsomagolás alatt";
      case 2:
        return "Futár felvételére vár";
      case 3:
        return "Kézbesítés alatt";
      case 4:
        return "Kiszállítva";
      case 5:
        return "Visszavont";
      default:
        return "Feldolgozás";
    }
  }
}
