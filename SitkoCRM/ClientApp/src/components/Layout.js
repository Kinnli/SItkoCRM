import React from 'react';
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Grid from "@material-ui/core/Grid";
import SearchIcon from "@material-ui/core/SvgIcon/SvgIcon";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import Tooltip from "@material-ui/core/Tooltip";
import IconButton from "@material-ui/core/IconButton";
import Paper from "@material-ui/core/Paper";
import RefreshIcon from '@material-ui/icons/Refresh';

export default props => (
    <Paper className={props.paper}>
        <AppBar className={props.searchBar} position="static" color="default" elevation={0}>
            <Toolbar>
                <Grid container spacing={2} alignItems="center">
                    <Grid item>
                        <SearchIcon className={props.block} color="inherit"/>
                    </Grid>
                    <Grid item xs>
                        <TextField
                            fullWidth
                            placeholder="Search by email address, phone number, or user UID"
                            InputProps={{
                                disableUnderline: true,
                                className: props.searchInput,
                            }}
                        />
                    </Grid>
                    <Grid item>
                        <Button variant="contained" color="primary" className={props.addUser}>
                            Add user
                        </Button>
                        <Tooltip title="Reload">
                            <IconButton>
                                <RefreshIcon className={props.block} color="inherit"/>
                            </IconButton>
                        </Tooltip>
                    </Grid>
                </Grid>
            </Toolbar>
        </AppBar>
        <div className={props.contentWrapper}>
            {props.children}
        </div>
    </Paper>
);
