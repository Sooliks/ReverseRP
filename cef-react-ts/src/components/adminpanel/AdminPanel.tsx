import React from 'react';
import {Config} from "../../conf";

const AdminPanel: React.FC = () => {
    return (
        <div style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', backgroundColor: 'white'}}>

        </div>
    );
};

export default AdminPanel;