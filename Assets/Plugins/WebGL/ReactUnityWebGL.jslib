mergeInto(LibraryManager.library, {
  Login: function () {
    try {
      dispatchReactUnityEvent("Login");
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
