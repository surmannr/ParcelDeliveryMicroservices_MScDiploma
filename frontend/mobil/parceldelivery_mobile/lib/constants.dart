class Constants {
  static SharedPref sharedPref = SharedPref();
  static Theme theme = Theme();
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
