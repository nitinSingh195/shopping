const initialState = {
    userName: null,
  };
  
  const userReducer = (state = initialState, action) => {
    switch (action.type) {
      case 'SET_USER_Name':
        return { ...state, userName: action.payload };
      default:
        return state;
    }
  };
  
  export default userReducer;