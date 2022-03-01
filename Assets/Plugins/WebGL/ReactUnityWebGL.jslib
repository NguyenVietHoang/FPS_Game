mergeInto(LibraryManager.library, {
  Login: function () {
    try {
      dispatchReactUnityEvent("Login");
    }catch(e) {

    }
   
  },
  LoginSuccess: function (message) {
      try {
      dispatchReactUnityEvent("LoginSuccess", Pointer_stringify(message));
    }catch(e) {

    }
   
  },
  ScoreUpdate: function (_score) {
     try {
     dispatchReactUnityEvent("ScoreUpdate", _score);
    }catch(e) {

    }
    
  }
});
