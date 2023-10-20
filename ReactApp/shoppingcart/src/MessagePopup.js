import React, { useState, useEffect } from 'react';

function MessagePopup({ message, type, onClose }) {
    useEffect(() => {
        // Automatically close the popup after 5 seconds
        const timeout = setTimeout(() => {
            onClose();
        }, 5000);

        return () => {
            clearTimeout(timeout);
        };
    }, [onClose]);

    return (
        <div className="message-popup position-fixed top-0 start-50 translate-middle-x">
            <div className={`alert alert-${type}`} role="alert">
                {message}
            </div>
        </div>
    );
}

export default MessagePopup;
