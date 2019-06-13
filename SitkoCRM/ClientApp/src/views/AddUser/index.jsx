import React, { Component } from 'react';

// Externals

// Material helpers
import { withStyles } from '@material-ui/core';

// Material components
import { Grid } from '@material-ui/core';

// Shared layouts
import { Dashboard as DashboardLayout } from 'layouts';

// Custom components
import { AddingForm} from './components';

// Component styles
const styles = theme => ({
    root: {
        padding: theme.spacing.unit * 4
    }
});

class Account extends Component {
    state = { tabIndex: 0 };

    render() {
        const { classes } = this.props;

        return (
            <DashboardLayout title="Account">
                <div className={classes.root}>
                    <Grid
                        container
                        spacing={4}
                    >
                        <Grid
                            item
                            lg={4}
                            md={6}
                            xl={4}
                            xs={12}
                        >
                            
                        </Grid>
                        <Grid
                            item
                            lg={8}
                            md={6}
                            xl={8}
                            xs={12}
                        >
                            <AddingForm />
                        </Grid>
                    </Grid>
                </div>
            </DashboardLayout>
        );
    }
}

export default withStyles(styles)(Account);