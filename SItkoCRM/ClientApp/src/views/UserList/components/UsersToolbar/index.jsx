import React, { Component } from 'react';
import { Link } from 'react-router-dom';
// Externals
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { Client } from 'components/entities/Client';
import { ClientsService } from 'components/services/ClientsService';
// Material helpers
import { withStyles } from '@material-ui/core';

// Material components
import { Button, IconButton } from '@material-ui/core';

// Material icons
import {
  ArrowDownward as ArrowDownwardIcon,
  ArrowUpward as ArrowUpwardIcon,
    Delete as DeleteIcon,
    Create as CreateIcon
} from '@material-ui/icons';

// Shared components
import { DisplayMode, SearchInput } from 'components';

// Component styles
import styles from './styles';

class UsersToolbar extends Component {

    handleDeleteUsers = e => {
        let client = new ClientsService();
        const cl = client.delete(this.props.selectedUsers);
    }

  render() {
    const { classes, className, selectedUsers } = this.props;

    const rootClassName = classNames(classes.root, className);

    return (
      <div className={rootClassName}>
          <div className={classes.row}>
              <span className={classes.spacer}/>
              {selectedUsers.length > 0 && (
            <IconButton
              className={classes.deleteButton}
              onClick={this.handleDeleteUsers}
            >
              <DeleteIcon />
            </IconButton>
            )}
              {selectedUsers.length > 0 && (
                    <Link to='/user{this.props.selectedUsers}'>
                <IconButton
                className={classes.createButton}
                >
                <CreateIcon />
                </IconButton>
            </Link>
            )}
              <Link to="/user">
                  <Button
                      color="primary"
                      size="small"
                      variant="outlined"
                  >
                      Add
                  </Button>
              </Link>
          </div>
          <div className={classes.row}>
              <SearchInput
                  className={classes.searchInput}
                  placeholder="Search user"
              />
              <span className={classes.spacer}/>
              <DisplayMode mode="list"/>
          </div>
      </div>
    );
  }
}

UsersToolbar.propTypes = {
  className: PropTypes.string,
  classes: PropTypes.object.isRequired,
  selectedUsers: PropTypes.array
};

UsersToolbar.defaultProps = {
  selectedUsers: []
};

export default withStyles(styles)(UsersToolbar);
