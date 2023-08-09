import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import {ConfigProvider} from "antd";


const classes = require('./Main.module.css');



const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);


root.render(
    <ConfigProvider componentSize={"middle"}>
        <App />
    </ConfigProvider>
);


