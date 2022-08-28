import { useState } from 'react';

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
            Site Logo
          </Grid>
          <Grid item xs={6}>
            <TextField
              className='header-search-input'
              variant="outlined" 
              InputProps={{
                placeholder:"Search",
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
              <ListItemIcon>
                <AccountCircleIcon fontSize="small" />
              </ListItemIcon>
              <ListItemText>My Profile</ListItemText>
            </MenuItem>
            <MenuItem>
              <ListItemIcon>
                <SettingsIcon fontSize="small" />
              </ListItemIcon>
              <ListItemText>Setting</ListItemText>
            </MenuItem>
            <MenuItem>
              <ListItemIcon>
                <LogoutIcon fontSize="small" />
              </ListItemIcon>
              <ListItemText>Logout</ListItemText>
            </MenuItem>
          </Menu>
          </Grid>
        </Grid>
      </Toolbar>
      <main>
        Main Content Container
      </main>
    </div>
  </>;
}

export default App;
