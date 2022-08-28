import { useState } from 'react';
import { Routes, Route, Link } from "react-router-dom";

import {
  Button,
  Grid,
  InputAdornment,
  ListItemIcon,
  ListItemText,
  Menu,
  MenuItem,
  TextField,
  Toolbar
} from '@mui/material';

import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import LogoutIcon from '@mui/icons-material/Logout';
import SearchIcon from '@mui/icons-material/Search';
import SettingsIcon from '@mui/icons-material/Settings';

import 'styles/App.scss';

function App() {

  const [menuAnchor, setMenuAnchor] = useState(null);

  const handleUserClick = (e) => {
    setMenuAnchor(e.currentTarget);
  };
  const handleMenuClose = () => {
    setMenuAnchor(null);
  }

  return <>
    <div className="app">
      <Toolbar
        className='app-toolbar'
      >
        <Grid container spacing={2}>
          <Grid item xs={2}>
            <Link to="/">
              Site Name    
            </Link>
          </Grid>
          <Grid item xs={6}>
            <TextField
              className='header-search-input'
              variant="outlined" 
              InputProps={{
                placeholder:"This Search Is Not Functional",
                startAdornment: (
                  <InputAdornment position="start">
                    <SearchIcon />
                  </InputAdornment>
                ),
              }}
            />
          </Grid>
          <Grid item xs={4}>
            <Button
              onClick={handleUserClick}
            >Account</Button>
            <Menu
              id="basic-menu"
              anchorEl={menuAnchor}
              open={menuAnchor}
              onClose={handleMenuClose}
              MenuListProps={{
                'aria-labelledby': 'basic-button',
              }}
            >
            <MenuItem>
              <Link to="/user">
                <ListItemIcon>
                  <AccountCircleIcon fontSize="small" />
                </ListItemIcon>
                <ListItemText>My Profile</ListItemText>
              </Link>
            </MenuItem>
            <MenuItem>
              <Link to="/settings">
                <ListItemIcon>
                  <SettingsIcon fontSize="small" />
                </ListItemIcon>
                <ListItemText>Settings</ListItemText>
              </Link>
            </MenuItem>
            <MenuItem>
              <Link to="/logout">
                <ListItemIcon>
                  <LogoutIcon fontSize="small" />
                </ListItemIcon>
                <ListItemText>Logout</ListItemText>
              </Link>
            </MenuItem>
          </Menu>
          </Grid>
        </Grid>
      </Toolbar>
      <main>
      <Routes>
        <Route path="/" element={<div>Home Test</div>} />
        <Route path="user" element={<div>User Test</div>} />
      </Routes>
      </main>
    </div>
  </>;
}

export default App;
