import React from "react";
import { Route, Routes } from "react-router-dom";
import { TabsMenu } from "../../components/compsIndex";
import {
  ExplorePage,
  NewsFeedPage,
  SettingsPage,
  TrendingPage,
} from "../pagesIndex";
import "./base-layout.scss";

export const BasePage = () => {
  return (
    <div className="full-page-wrapper flex flex-column">
      <div className="header-wrapper flex flex-column">
        <div className="header-title flex">
          <span>BreakingNews</span>
        </div>
        <div className="header-nav flex flex-fill-remaining">
          <TabsMenu />
        </div>
      </div>
      <div className="content-footer-wrapper">
        <div className="content-wrapper flex-fill-remaining">
          <Routes>
            <Route path="/" element={<NewsFeedPage />} />
            <Route path="/trending" element={<TrendingPage />} />
            <Route path="/explore" element={<ExplorePage />} />
            <Route path="/settings" element={<SettingsPage />} />
          </Routes>
        </div>
        <div className="footer-wrapper">
          <span className="footer-text">BreakingNews@AmirOffir</span>
        </div>
      </div>
    </div>
  );
};
