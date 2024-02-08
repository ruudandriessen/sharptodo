export const getAuthHeaders = () => {
    const token = sessionStorage.getItem('token');

    if (!token) {
        return {};
    }
  
    return {
        'Authorization': `Bearer ${token}`,
    };
};