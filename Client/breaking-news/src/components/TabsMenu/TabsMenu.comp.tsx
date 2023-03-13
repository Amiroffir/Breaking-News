import React from "react";
import { Link } from "react-router-dom";
import "./tabs-menu.scss";

export const TabsMenu = () => {
  return (
    <ul className="nav nav-tabs">
      <li className="nav-item">
        <Link className="nav-link tab-link" to="/">
          Your Feed
        </Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link tab-link" to="/trending">
          Trending
        </Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link tab-link" to="/explore">
          Explore
        </Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link tab-link" to="/settings">
          Settings
        </Link>
      </li>
    </ul>
  );
};
